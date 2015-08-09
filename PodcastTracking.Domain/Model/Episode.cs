using System;
using System.Collections.Generic;

namespace PodcastTracking.Domain.Model
{
    public class Episode
    {
        public Episode()
        {
            Downloads = new List<Download>();
        }
        public int EpisodeId { get; set; }
        public int PodcastId { get; set; } 
        public string Title { get; set; }
        public DateTime PublishDate { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string EpisodeUrl { get; set; }
        public string EpisodeDownloadUrl { get; set; }
        public string Image { get; set; }
        public virtual ICollection<Download> Downloads { get; set; }
        public virtual Podcast Podcast { get; set; }
    }
}
