using PodcastTracking.Data.Repository;
using System.Web.Mvc;

namespace PodcastTracking.Web.Controllers
{
    public class HomeController : Controller
    {
        private IPodcastRepository _podcastRepository;

        public HomeController(IPodcastRepository podcastRepository)
        {
            _podcastRepository = podcastRepository;

        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}