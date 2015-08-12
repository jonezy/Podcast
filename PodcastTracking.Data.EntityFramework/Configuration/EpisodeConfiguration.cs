using PodcastTracking.Domain.Model;
using System.Data.Entity.ModelConfiguration;

namespace PodcastTracking.Data.EntityFramework.Configuration
{
    class EpisodeConfiguration : EntityTypeConfiguration<Episode>
    {
        public EpisodeConfiguration()
        {
            HasKey(e => e.EpisodeId);

            //HasRequired<Podcast>(p => p.Podcast)
            //    .WithMany(e => e.Episodes)
            //    .HasForeignKey(p => p.EpisodeId);
        }
    }
}
