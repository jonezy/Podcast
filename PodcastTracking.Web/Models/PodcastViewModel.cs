using PodcastTracking.Domain.Model;
using System.Collections.Generic;

namespace PodcastTracking.Web.Models
{
    public class PodcastViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public List<Episode> Episodes { get; set; }
    }
}