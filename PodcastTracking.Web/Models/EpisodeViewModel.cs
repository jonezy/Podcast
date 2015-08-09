using System;
using System.Collections.Generic;

namespace PodcastTracking.Web.Models
{
    public class EpisodeViewModel
    {
        public int EpisodeId { get; set; }
        public string Title { get; set; }
        public DateTime PublishDate { get; set; }
        public string Description { get; set; }
        public string Author { get; set;}
        public string EpisodeDownloadUrl { get; set; }
        public int DownloadCount { get; set; }
        public string Image { get; set; }
        public List<DownloadViewModel> Downloads { get; set; }
    }
}