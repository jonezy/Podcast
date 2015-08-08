using System.Linq;
using PodcastTracking.Data.Repository;
using PodcastTracking.Domain.Model;
using PodcastTracking.Domain.Service;
using System.Xml.Linq;

namespace PodcastTracking.Web.Application.Services
{
    public interface IFeedImportingService
    {
        int Import(string feedUrl);
    }

    public class FeedImportingService : IFeedImportingService
    {
        private IFeedLoader _feedLoader;
        private IMultipleFeedParser<Episode> _epiosdeParser;
        private IFeedParser<Podcast> _podcastParser;
        private IFeedParser<Publisher> _publisherParser;
        private IPublisherRepository _publisherRepository;
        private IPodcastRepository _podcastRepository;
        private IEpisodeService _episodeService;

        public FeedImportingService(IFeedLoader feedLoader, 
            IMultipleFeedParser<Episode> episodeParser, 
            IFeedParser<Podcast> podcastParser, 
            IFeedParser<Publisher> publisherParser, 
            IPublisherRepository publisherRepository,
            IPodcastRepository podcastRepository,
            IEpisodeService episodeService)
        {
            _feedLoader = feedLoader;
            _epiosdeParser = episodeParser;
            _podcastParser = podcastParser;
            _publisherParser = publisherParser;
            _publisherRepository = publisherRepository;
            _podcastRepository = podcastRepository;
            _episodeService = episodeService;
        }

        public int Import(string feedUrl)
        {
            var existingPodcast = _podcastRepository.Find(p => p.FeedUrl == feedUrl);

            XDocument xml = _feedLoader.Load(feedUrl);
            var episodes = _epiosdeParser.Parse(xml, feedUrl);
            if(existingPodcast != null)
            {
                existingPodcast.Episodes = _episodeService.UpdateEpisodes(existingPodcast.Episodes.ToList(), episodes);
                _publisherRepository.InsertOrUpdate(existingPodcast.Publisher);
                return existingPodcast.PodcastId;
            }

            var podcast = _podcastParser.Parse(xml, feedUrl);
            var publisher = _publisherParser.Parse(xml, feedUrl);

            podcast.Episodes = episodes;
            publisher.Podcasts.Add(podcast);

            _publisherRepository.InsertOrUpdate(publisher);

            return publisher.Podcasts.First(p => p.FeedUrl == feedUrl).PodcastId;
        }
    }
}
