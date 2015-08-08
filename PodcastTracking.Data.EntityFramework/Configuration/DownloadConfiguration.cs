using PodcastTracking.Domain.Model;
using System.Data.Entity.ModelConfiguration;

namespace PodcastTracking.Data.EntityFramework.Configuration
{
    class DownloadConfiguration : EntityTypeConfiguration<Download>
    {
        public DownloadConfiguration()
        {
            HasKey(d => d.DownloadId);
        }
    }
}
