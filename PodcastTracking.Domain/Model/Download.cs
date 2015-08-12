using System;

namespace PodcastTracking.Domain.Model
{
    public class Download
    {
        public int DownloadId { get; set; }
        public int EpisodeId { get; set; }
        public DateTime DateTime { get; set; }
        public string IPAddress { get; set; }
        public string Referer { get; set; }
        public string UserAgent { get; set; }

        public virtual Episode Episode { get; set; }
    }
}
