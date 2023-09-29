using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nop.Services.Blogs;
using Nop.Services.News;
using Nop.Services.Seo;
using Nop.Services.Topics;

namespace Nop.Web.Controllers
{
    //do not inherit it from BasePublicController. otherwise a lot of extra action filters will be called
    //they can create guest account(s), etc
    public partial class BackwardCompatibility2XController : Controller
    {
        #region Fields

        private readonly IBlogService _blogService;
        private readonly INewsService _newsService;
        private readonly ITopicService _topicService;
        private readonly IUrlRecordService _urlRecordService;

        #endregion

        #region Ctor

        public BackwardCompatibility2XController(IBlogService blogService,
            INewsService newsService,
            ITopicService topicService,
            IUrlRecordService urlRecordService)
        {
            _blogService = blogService;
            _newsService = newsService;
            _topicService = topicService;
            _urlRecordService = urlRecordService;
        }

        #endregion

        #region Methods

        //in versions 2.00-2.70 we had ID in news URLs
        public virtual async Task<IActionResult> RedirectNewsItemById(int newsItemId)
        {
            var newsItem = await _newsService.GetNewsByIdAsync(newsItemId);
            if (newsItem == null)
                return RedirectToRoutePermanent("Homepage");

            return RedirectToRoutePermanent("NewsItem", new { SeName = await _urlRecordService.GetSeNameAsync(newsItem, newsItem.LanguageId, ensureTwoPublishedLanguages: false) });
        }

        //in versions 2.00-2.70 we had ID in blog URLs
        public virtual async Task<IActionResult> RedirectBlogPostById(int blogPostId)
        {
            var blogPost = await _blogService.GetBlogPostByIdAsync(blogPostId);
            if (blogPost == null)
                return RedirectToRoutePermanent("Homepage");

            return RedirectToRoutePermanent("BlogPost", new { SeName = await _urlRecordService.GetSeNameAsync(blogPost, blogPost.LanguageId, ensureTwoPublishedLanguages: false) });
        }

        //in versions 2.00-3.20 we had SystemName in topic URLs
        public virtual async Task<IActionResult> RedirectTopicBySystemName(string systemName)
        {
            var topic = await _topicService.GetTopicBySystemNameAsync(systemName);
            if (topic == null)
                return RedirectToRoutePermanent("Homepage");

            return RedirectToRoutePermanent("Topic", new { SeName = await _urlRecordService.GetSeNameAsync(topic) });
        }

        #endregion
    }
}