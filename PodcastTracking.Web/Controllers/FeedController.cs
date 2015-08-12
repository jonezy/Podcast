using PodcastTracking.Web.Application.Services;
using PodcastTracking.Web.Models;
using System.Web.Mvc;

//http://www.the416.net/416/?format=rss
namespace PodcastTracking.Web.Controllers
{
    public class FeedController : Controller
    {
        private IFeedImportingService _service;
        private IFeedService _feedService;

        public FeedController(IFeedImportingService service, IFeedService feedService)
        {
            _service = service;
            _feedService = feedService;
        }

        public ActionResult Import()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Import(ImportFeedEditModel model)
        {
            var id = _service.Import(model.FeedUrl);

            return RedirectToAction("index", "podcast", new { @id = id });
        }

        public string Feed(int id)
        {
            var feed = _feedService.GenerateFeed(id);

            Response.ContentType = "text/xml";

            return feed;
        }
    }
}