using System.Collections.Generic;

namespace PodcastTracking.Domain.Model
{
    public class Publisher
    {
        public Publisher()
        {
            Podcasts = new List<Podcast>();
        }

        public int PublisherId { get; set; }
        public string Name { get; set; }
        public string Website { get; set; }
        public virtual ICollection<Podcast> Podcasts { get; set; }
    }
}
