using PodcastTracking.Domain.Model;
using System.Collections.Generic;

namespace PodcastTracking.Web.Models
{
    public class PodcastViewModel
    {
        public int PodcastId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public FeedViewModel Feed { get; set; }
        public List<EpisodeViewModel> Episodes { get; set; }
    }
}