﻿using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Core.Domain.Media;
using Nop.Core.Infrastructure;
using Nop.Services.Logging;
using Nop.Services.Media;

namespace Nop.Web.Areas.Admin.Controllers
{
    public partial class DownloadController : BaseAdminController
    {
        #region Fields

        private readonly IDownloadService _downloadService;
        private readonly ILogger _logger;
        private readonly INopFileProvider _fileProvider;
        private readonly IWorkContext _workContext;

        #endregion

        #region Ctor

        public DownloadController(IDownloadService downloadService,
            ILogger logger,
            INopFileProvider fileProvider,
            IWorkContext workContext)
        {
            _downloadService = downloadService;
            _logger = logger;
            _fileProvider = fileProvider;
            _workContext = workContext;
        }

        #endregion

        #region Methods

        public virtual async Task<IActionResult> DownloadFile(Guid downloadGuid)
        {
            var download = await _downloadService.GetDownloadByGuidAsync(downloadGuid);
            if (download == null)
                return Content("No download record found with the specified id");

            //A warning (SCS0027 - Open Redirect) from the "Security Code Scan" analyzer may appear at this point. 
            //In this case, it is not relevant. Url may not be local.
            if (download.UseDownloadUrl)
                return new RedirectResult(download.DownloadUrl);

            //use stored data
            if (download.DownloadBinary == null)
                return Content($"Download data is not available any more. Download GD={download.Id}");

            var fileName = (!string.IsNullOrWhiteSpace(download.Filename) ? download.Filename : download.Id.ToString()) + download.Extension;
            var fileBinary = download.DownloadBinary;
            if (download.DownloadBinary.Length == 0)
            {
                var filePath = _fileProvider.MapPath(string.Format(NopMediaDefaults.DefaultNotesFilesFolder, download.DownloadGuid));
                fileName = download.Filename + download.Extension;
                filePath = _fileProvider.Combine(filePath, fileName);

                if (!_fileProvider.FileExists(filePath))
                    return Content($"Download data is not available any more. Download GD={download.Id}");

                fileBinary = await _fileProvider.ReadAllBytesAsync(filePath);
            }

            var contentType = !string.IsNullOrWhiteSpace(download.ContentType)
                ? download.ContentType
                : MimeTypes.ApplicationOctetStream;
            return new FileContentResult(fileBinary, contentType)
            {
                FileDownloadName = fileName
            };
        }

        [HttpPost]
        public virtual async Task<IActionResult> SaveDownloadUrl(string downloadUrl)
        {
            //don't allow to save empty download object
            if (string.IsNullOrEmpty(downloadUrl))
            {
                return Json(new
                {
                    success = false,
                    message = "Please enter URL"
                });
            }

            //insert
            var download = new Download
            {
                DownloadGuid = Guid.NewGuid(),
                UseDownloadUrl = true,
                DownloadUrl = downloadUrl,
                IsNew = true
            };
            await _downloadService.InsertDownloadAsync(download);

            return Json(new { success = true, downloadId = download.Id });
        }

        [HttpPost]
        //do not validate request token (XSRF)
        [IgnoreAntiforgeryToken]
        public virtual async Task<IActionResult> AsyncUpload()
        {
            var httpPostedFile = Request.Form.Files.FirstOrDefault();
            if (httpPostedFile == null)
            {
                return Json(new
                {
                    success = false,
                    message = "No file uploaded"
                });
            }

            var fileBinary = await _downloadService.GetDownloadBitsAsync(httpPostedFile);

            var qqFileNameParameter = "qqfilename";
            var fileName = httpPostedFile.FileName;
            if (string.IsNullOrEmpty(fileName) && Request.Form.ContainsKey(qqFileNameParameter))
                fileName = Request.Form[qqFileNameParameter].ToString();
            //remove path (passed in IE)
            fileName = _fileProvider.GetFileName(fileName);

            var contentType = httpPostedFile.ContentType;

            var fileExtension = _fileProvider.GetFileExtension(fileName);
            if (!string.IsNullOrEmpty(fileExtension))
                fileExtension = fileExtension.ToLowerInvariant();

            var download = new Download
            {
                DownloadGuid = Guid.NewGuid(),
                UseDownloadUrl = false,
                DownloadUrl = string.Empty,
                DownloadBinary = new byte[0],
                //DownloadBinary = fileBinary,
                ContentType = contentType,
                //we store filename without extension for downloads
                Filename = _fileProvider.GetFileNameWithoutExtension(fileName),
                Extension = fileExtension,
                IsNew = true
            };

            try
            {
                await _downloadService.InsertDownloadAsync(download);

                var uploadPath = _fileProvider.MapPath(string.Format(NopMediaDefaults.DefaultNotesFilesFolder, download.DownloadGuid));
                if (!_fileProvider.DirectoryExists(uploadPath))
                    _fileProvider.CreateDirectory(uploadPath);

                uploadPath = _fileProvider.Combine(uploadPath, fileName);

                //delete the file if already exist
                if (_fileProvider.FileExists(uploadPath))
                    _fileProvider.DeleteFile(uploadPath);

                await _fileProvider.WriteAllBytesAsync(uploadPath, fileBinary);

                //when returning JSON the mime-type must be set to text/plain
                //otherwise some browsers will pop-up a "Save As" dialog.
                return Json(new
                {
                    success = true,
                    downloadId = download.Id,
                    downloadUrl = Url.Action("DownloadFile", new { downloadGuid = download.DownloadGuid })
                });
            }
            catch (Exception exc)
            {
                await _logger.ErrorAsync(exc.Message, exc, await _workContext.GetCurrentCustomerAsync());

                return Json(new
                {
                    success = false,
                    message = "File cannot be saved"
                });
            }
        }

        #endregion
    }
}