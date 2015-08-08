using AutoMapper;
using PodcastTracking.Data.Repository;
using PodcastTracking.Web.Models;
using System.Web.Mvc;

namespace PodcastTracking.Web.Controllers
{
    public class PodcastController : Controller
    {
        private IPodcastRepository _repository;

        public PodcastController(IPodcastRepository repository)
        {
            _repository = repository;
        }

        public ActionResult Index(int id)
        {
            var podcast = _repository.Find(p => p.PodcastId == id);
            var viewModel = Mapper.Map<PodcastViewModel>(podcast);

            return View(viewModel);
        }
    }
}