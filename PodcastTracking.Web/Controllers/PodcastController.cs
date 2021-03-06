﻿using AutoMapper;
using PodcastTracking.Data.Repository;
using PodcastTracking.Web.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace PodcastTracking.Web.Controllers
{
    public class PodcastController : Controller
    {
        private IPodcastRepository _repository;
        private IEpisodeRepository _episodeRepository;

        public PodcastController(IPodcastRepository repository, IEpisodeRepository episodeRepository)
        {
            _repository = repository;
            _episodeRepository = episodeRepository;
        }

        public ActionResult All()
        {
            var podcasts = _repository.GetAll();
            var viewModel = Mapper.Map<List<PodcastViewModel>>(podcasts);

            return View(viewModel.OrderBy(p => p.Title).ToList());
        }

        public ActionResult Index(int id)
        {
            var podcast = _repository.Find(p => p.PodcastId == id);
            var viewModel = Mapper.Map<PodcastViewModel>(podcast);

            return View(viewModel);
        }

        public ActionResult Downloads(int id)
        {
            var episode = _episodeRepository.Find(e => e.EpisodeId == id);
            var viewModel = Mapper.Map<List<DownloadViewModel>>(episode.Downloads);

            return View(viewModel);
        }
    }
}