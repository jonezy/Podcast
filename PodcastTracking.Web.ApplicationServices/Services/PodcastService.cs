using PodcastTracking.Data.Repository;
using PodcastTracking.Domain.Model;
using System;
using System.Web;

namespace PodcastTracking.Web.Application.Services
{
    public interface IPodcastService
    {
        void TrackEpisodeDownload(string episodeUrl, HttpRequestBase request);
    }
    public class PodcastService : IPodcastService
    {
        private IEpisodeRepository _repository;

        public PodcastService(IEpisodeRepository repository)
        {
            _repository = repository;
        }

        public void TrackEpisodeDownload(string episodeUrl, HttpRequestBase request)
        {
            var episode = _repository.Find(e => e.EpisodeDownloadUrl == episodeUrl);
            episode.Downloads.Add(new Download
            {
                DateTime = DateTime.Now,
                IPAddress = request.UserHostAddress,
                Referer = request.UrlReferrer.ToString(),
                UserAgent = request.UserAgent
            });

            _repository.InsertOrUpdate(episode);
        }
    }
}
