using PodcastTracking.Domain.Model;
using System.Data.Entity.ModelConfiguration;

namespace PodcastTracking.Data.EntityFramework.Configuration
{
    public class FeedConfiguration : EntityTypeConfiguration<Feed>
    {
        public FeedConfiguration()
        {
            HasKey(f => f.FeedId);
            HasRequired<Podcast>(p => p.Podcast);
        }
    }
}
