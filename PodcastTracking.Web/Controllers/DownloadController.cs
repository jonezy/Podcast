using PodcastTracking.Web.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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

        public ActionResult Track(string url)
        {
            _podcastService.TrackEpisodeDownload(url, Request);

            Response.Redirect(url);

            return new EmptyResult();
        }
    }
}