using System;
using System.Collections.Generic;

namespace PodcastTracking.Domain.Model
{
    public class Podcast
    {
        public Podcast()
        {
            Episodes = new List<Episode>();
        }

        public int PodcastId { get; set; }
        public int PublisherId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public string Category { get; set; }
        public string FeedUrl { get; set; }
        public string Image { get; set; }
        public DateTime LastUpdated { get; set; }
        public virtual ICollection<Episode> Episodes { get; set; }

        public virtual Publisher Publisher { get; set; }
        public virtual Feed Feed { get; set; }
    }
}