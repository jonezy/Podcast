using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PodcastTracking.Web.Models
{
    public class EpisodeViewModel
    {
        public string Title { get; set; }
        public DateTime PublishDate { get; set; }
        public string Description { get; set; }
        public string Author { get; set;}
    }
}