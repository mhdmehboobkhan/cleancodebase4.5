using System;
using System.ComponentModel.DataAnnotations;
using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Nop.Web.Models.Customer
{
    /// <summary>
    /// Represents an customer note model
    /// </summary>
    public partial record CustomerNoteModel : BaseNopEntityModel
    {
        #region Properties

        [NopResourceDisplayName("Admin.Customers.CustomerNotes.Fields.Customer")]
        public int CustomerId { get; set; }

        [NopResourceDisplayName("Admin.Customers.CustomerNotes.Fields.DisplayToCustomer")]
        public bool DisplayToCustomer { get; set; }

        [NopResourceDisplayName("Admin.Customers.CustomerNotes.Fields.Note")]
        public string Note { get; set; }

        [NopResourceDisplayName("Admin.Customers.CustomerNotes.Fields.Download")]
        [UIHint("Download")]
        public int DownloadId { get; set; }
        public bool HasDownload { get; set; }

        [NopResourceDisplayName("Admin.Customers.CustomerNotes.Fields.Download")]
        public Guid DownloadGuid { get; set; }

        [NopResourceDisplayName("Admin.Customers.CustomerNotes.Fields.CreatedOn")]
        public DateTime CreatedOn { get; set; }

        #endregion
    }
}