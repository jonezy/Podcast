using NUnit.Framework;
using PodcastTracking.Data.EntityFramework;
using PodcastTracking.Domain.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace PodcastTracking.Data.Test.Integration
{
    [TestFixture]
    public class DataTests
    {
        private PodcastTrackingContext _context;

        [TestFixtureSetUp]
        public void SetUp()
        {
            _context = new PodcastTrackingContext(ConfigurationManager.ConnectionStrings["PodcastTrackingTest"].ConnectionString);
            _context.Database.Initialize(true);

            var publisher = new Publisher
            {
                Name = "The 416",
                Website = "http://the416.net",
                Podcasts = new List<Podcast> {
                    new Podcast
                    {
                        Title = "The 416 Show",
                        FeedUrl = "http://the416.net/416/rss/",
                        Description = "A show about topics and things",
                        LastUpdated = DateTime.Now.AddDays(-5),
                        Episodes = new List<Episode> {
                            new Episode {
                                EpisodeUrl = "http://the416.net/416/20",
                                Author = "Chris",
                                EpisodeDownloadUrl="http://the416.net/416/EP20.mp3",
                                Description="EPisode 20 description",
                                Downloads = new List<Download>()
                                {
                                    new Download {
                                        DownloadId = 1,
                                        IPAddress = "10.0.0.1",
                                        DateTime = DateTime.Now
                                    }
                                },
                                PublishDate=DateTime.Now.AddDays(-7),
                                Title="Episode 20: Writing the unit tests"
                            }
                        }
                    }
                }
            };

            _context.Publishers.Add(publisher);
            _context.SaveChanges();
        }

        [TestFixtureTearDown]
        public void TearDown()
        {
            _context.Database.Delete();
        }

        [Test]
        public void Can_Retreive_Podcast_By_Id()
        {
            var actual = _context.Podcasts.FirstOrDefault(p => p.PodcastId == 1);

            Assert.IsNotNull(actual);
        }

        [Test]
        public void Can_Retreive_Podcast_Downloads()
        {
            var actual = _context.Podcasts.First().Episodes.First().Downloads;

            Assert.IsNotNull(actual);
        }

        [Test]
        public void Can_Retreive_Podcast_Episode_By_EpisodeUrl()
        {
            var episodeUrl = "http://the416.net/416/20";
            var podcasts = _context.Podcasts;
            Episode episode = null;
            foreach (var podcast in podcasts)
            {
                episode = podcast.Episodes.FirstOrDefault(e => e.EpisodeUrl == episodeUrl);
                if (episode == null)
                    continue;
            }

            Assert.IsNotNull(episode);
        }
    }
}
