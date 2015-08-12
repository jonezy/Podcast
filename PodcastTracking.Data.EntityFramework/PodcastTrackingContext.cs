using PodcastTracking.Data.EntityFramework.Configuration;
using PodcastTracking.Domain.Model;
using System.Data.Entity;

namespace PodcastTracking.Data.EntityFramework
{
    public class PodcastTrackingContext : DbContext
    {
        public PodcastTrackingContext()
        {
            Configuration.LazyLoadingEnabled = true;
        }

        public PodcastTrackingContext(string nameOrConnectionString) : base(nameOrConnectionString)
        {
            Database.SetInitializer<PodcastTrackingContext>(new DropCreateDatabaseIfModelChanges<PodcastTrackingContext>());
            Configuration.LazyLoadingEnabled = true;
        }

        public virtual DbSet<Publisher> Publishers { get; set; }
        public virtual DbSet<Podcast> Podcasts {get; set;}
        public virtual DbSet<Episode> Episodes { get; set; }
        public virtual DbSet<Download> Downloads { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new DownloadConfiguration());
            modelBuilder.Configurations.Add(new EpisodeConfiguration());
            modelBuilder.Configurations.Add(new PodcastConfiguration());
            modelBuilder.Configurations.Add(new PublisherConfiguration());
            modelBuilder.Configurations.Add(new FeedConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
