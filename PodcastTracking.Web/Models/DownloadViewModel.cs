using System;

namespace PodcastTracking.Web.Models
{
    public class DownloadViewModel
    {
        public DateTime DateTime { get; set; }
        public string IPAddress { get; set; }
        public string Referer { get; set; }
        public string UserAgent { get; set; }
    }
}