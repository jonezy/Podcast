using PodcastTracking.Data.Repository;
using PodcastTracking.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace PodcastTracking.Web.Application.Services
{
    public interface IPodcastService
    {
        void TrackEpisodeDownload(string episodeUrl, HttpRequestBase request);
    }
    public class PodcastService : IPodcastService
    {
        private IPodcastRepository _repository;

        public PodcastService(IPodcastRepository repository)
        {
            _repository = repository;
        }

        public void TrackEpisodeDownload(string episodeUrl, HttpRequestBase request)
        {
            var podcasts = _repository.GetAll();
            Podcast podcast = null;
            Episode episode = null;
            foreach (var p in podcasts)
            {
                episode = p.Episodes.FirstOrDefault(e => e.EpisodeUrl.Contains(episodeUrl));
                podcast = p;
                if (episode == null)
                    continue;
            }

            episode.Downloads.Add(new Download
            {
                DateTime = DateTime.Now,
                IPAddress = request.UserHostAddress
            });

            _repository.InsertOrUpdate(podcast);
        }
    }
}
