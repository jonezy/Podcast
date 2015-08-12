using System;

namespace PodcastTracking.Domain.Model
{
    public class Feed
    {
        public int FeedId { get; set; }
        public int PodcastId { get; set; }
        public string FeedContents { get; set; }
        public DateTime LastUpdated { get; set; }

        public virtual Podcast Podcast { get; set; }
    }
}
