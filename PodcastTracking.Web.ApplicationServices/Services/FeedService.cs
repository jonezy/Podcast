using PodcastTracking.Data.Repository;
using PodcastTracking.Domain.Model;
using System;

namespace PodcastTracking.Web.Application.Services
{
    public interface IFeedService
    {
        string GenerateFeed(int id);
    }

    public class FeedService : IFeedService
    {
        private readonly IFeedGenerator _feedGenerator;
        private readonly IPodcastRepository _podcastRepository;
        private readonly IFeedRepository _feedRepository;

        public FeedService(IFeedGenerator feedGenerator, IPodcastRepository podcastRepository, IFeedRepository feedRepository)
        {
            _feedGenerator = feedGenerator;
            _podcastRepository = podcastRepository;
            _feedRepository = feedRepository;
        }

        public string GenerateFeed(int id)
        {
            var podcast = _podcastRepository.Find(p => p.PodcastId == id);
            var feed = podcast.Feed;
            var feedContents = string.Empty;
            if(feed != null)
            {
                if(feed.LastUpdated <= DateTime.Now.AddMinutes(-60))
                {
                    feedContents = _feedGenerator.GenerateFeed(podcast.FeedUrl);
                    feed.FeedContents = feedContents;
                    feed.LastUpdated = DateTime.Now;
                    _podcastRepository.InsertOrUpdate(podcast);
                }

                feedContents = feed.FeedContents;
            }
            else
            {
                feedContents = _feedGenerator.GenerateFeed(podcast.FeedUrl);
                feed = new Feed
                {
                    FeedContents = feedContents,
                    LastUpdated = DateTime.Now
                };

                podcast.Feed = feed;
                _podcastRepository.InsertOrUpdate(podcast);
            }

            return feedContents;
        }
    }
}
