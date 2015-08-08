using PodcastTracking.Domain.Model;
using System.Data.Entity.ModelConfiguration;

namespace PodcastTracking.Data.EntityFramework.Configuration
{
    class PodcastConfiguration : EntityTypeConfiguration<Podcast>
    {
        public PodcastConfiguration()
        {
            HasKey(p => p.PodcastId);

            HasRequired<Publisher>(p => p.Publisher)
                .WithMany(p => p.Podcasts)
                .HasForeignKey(p => p.PublisherId);
        }
    }
}
