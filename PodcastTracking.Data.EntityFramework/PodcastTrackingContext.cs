﻿using PodcastTracking.Domain.Model;
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
    }
}
