using PodcastTracking.Web.Application.Services;
using System.Web.Mvc;

namespace PodcastTracking.Web.Controllers
{
    public class DownloadController : Controller
    {
        private IPodcastService _podcastService;

        public DownloadController(IPodcastService podcastService)
        {
            _podcastService = podcastService;
        }

        public ActionResult Track(string urlToTrack)
        {
            _podcastService.TrackEpisodeDownload(urlToTrack, Request);

            Response.Redirect(urlToTrack);

            return new EmptyResult();
        }
    }
}