using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Services.Blogs;
using Nop.Services.Customers;
using Nop.Services.News;
using Nop.Services.Seo;
using Nop.Services.Topics;

namespace Nop.Web.Controllers
{
    //do not inherit it from BasePublicController. otherwise a lot of extra action filters will be called
    //they can create guest account(s), etc
    public partial class BackwardCompatibility1XController : Controller
    {
        #region Fields

        private readonly IBlogService _blogService;
        private readonly ICustomerService _customerService;
        private readonly INewsService _newsService;
        private readonly ITopicService _topicService;
        private readonly IUrlRecordService _urlRecordService;
        private readonly IWebHelper _webHelper;

        #endregion

        #region Ctor

        public BackwardCompatibility1XController(IBlogService blogService,
            ICustomerService customerService,
            INewsService newsService,
            ITopicService topicService,
            IUrlRecordService urlRecordService,
            IWebHelper webHelper)
        {
            _blogService = blogService;
            _customerService = customerService;
            _newsService = newsService;
            _topicService = topicService;
            _urlRecordService = urlRecordService;
            _webHelper = webHelper;
        }

        #endregion

        #region Methods

        public virtual async Task<IActionResult> GeneralRedirect()
        {
            // use Request.RawUrl, for instance to parse out what was invoked
            // this regex will extract anything between a "/" and a ".aspx"
            var regex = new Regex(@"(?<=/).+(?=\.aspx)", RegexOptions.Compiled);
            var rawUrl = _webHelper.GetRawUrl(HttpContext.Request);
            var aspxfileName = regex.Match(rawUrl).Value.ToLowerInvariant();

            switch (aspxfileName)
            {
                //URL without rewriting
                case "news":
                    {
                        return await RedirectNewsItem(_webHelper.QueryString<string>("newsid"), false);
                    }
                case "blog":
                    {
                        return await RedirectBlogPost(_webHelper.QueryString<string>("blogpostid"), false);
                    }
                case "topic":
                    {
                        return await RedirectTopic(_webHelper.QueryString<string>("topicid"), false);
                    }
                case "profile":
                    {
                        return await RedirectUserProfile(_webHelper.QueryString<string>("UserId"));
                    }
                case "contactus":
                    {
                        return RedirectToRoutePermanent("ContactUs");
                    }
                case "passwordrecovery":
                    {
                        return RedirectToRoutePermanent("PasswordRecovery");
                    }
                case "login":
                    {
                        return RedirectToRoutePermanent("Login");
                    }
                case "register":
                    {
                        return RedirectToRoutePermanent("Register");
                    }
                case "newsarchive":
                    {
                        return RedirectToRoutePermanent("NewsArchive");
                    }
                case "sitemap":
                    {
                        return RedirectToRoutePermanent("Sitemap");
                    }
                default:
                    break;
            }

            //no permanent redirect in this case
            return RedirectToRoute("Homepage");
        }

        public virtual async Task<IActionResult> RedirectNewsItem(string id, bool idIncludesSename = true)
        {
            //we can't use dash in MVC
            var newsId = idIncludesSename ? Convert.ToInt32(id.Split(new[] { '-' })[0]) : Convert.ToInt32(id);
            var newsItem = await _newsService.GetNewsByIdAsync(newsId);
            if (newsItem == null)
                return RedirectToRoutePermanent("Homepage");

            return RedirectToRoutePermanent("NewsItem", new { newsItemId = newsItem.Id, SeName = await _urlRecordService.GetSeNameAsync(newsItem, newsItem.LanguageId, ensureTwoPublishedLanguages: false) });
        }

        public virtual async Task<IActionResult> RedirectBlogPost(string id, bool idIncludesSename = true)
        {
            //we can't use dash in MVC
            var blogPostId = idIncludesSename ? Convert.ToInt32(id.Split(new[] { '-' })[0]) : Convert.ToInt32(id);
            var blogPost = await _blogService.GetBlogPostByIdAsync(blogPostId);
            if (blogPost == null)
                return RedirectToRoutePermanent("Homepage");

            return RedirectToRoutePermanent("BlogPost", new { blogPostId = blogPost.Id, SeName = await _urlRecordService.GetSeNameAsync(blogPost, blogPost.LanguageId, ensureTwoPublishedLanguages: false) });
        }

        public virtual async Task<IActionResult> RedirectTopic(string id, bool idIncludesSename = true)
        {
            //we can't use dash in MVC
            var topicId = idIncludesSename ? Convert.ToInt32(id.Split(new[] { '-' })[0]) : Convert.ToInt32(id);
            var topic = await _topicService.GetTopicByIdAsync(topicId);
            if (topic == null)
                return RedirectToRoutePermanent("Homepage");

            return RedirectToRoutePermanent("Topic", new { SeName = await _urlRecordService.GetSeNameAsync(topic) });
        }

        public virtual async Task<IActionResult> RedirectUserProfile(string id)
        {
            //we can't use dash in MVC
            var userId = Convert.ToInt32(id);
            var user = await _customerService.GetCustomerByIdAsync(userId);
            if (user == null)
                return RedirectToRoutePermanent("Homepage");

            return RedirectToRoutePermanent("CustomerProfile", new { id = user.Id });
        }

        #endregion
    }
}