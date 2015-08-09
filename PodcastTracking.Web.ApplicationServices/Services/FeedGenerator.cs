using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace PodcastTracking.Web.Application.Services
{
    public interface IFeedGenerator
    {
        string GenerateFeed(string feedUrl);

    }
    public class FeedGenerator : IFeedGenerator
    {
        private IFeedLoader _feedLoader;

        public FeedGenerator(IFeedLoader feedLoader)
        {
            _feedLoader = feedLoader;
        }

        public string GenerateFeed(string feedUrl)
        {
            XDocument xml = _feedLoader.Load(feedUrl);

            var channel = (from c in xml.Descendants("channel") select c).SingleOrDefault();

            IEnumerable<XElement> episodes =
                from episode in channel.Descendants("item")
                select episode;
            foreach (var episode in episodes)
            {
                var existingDownloadUrl = episode.Element("enclosure").Attribute("url").Value;
                episode.Element("enclosure").Attribute("url").SetValue(string.Format("http://tracking.local/download/track/?u={0}", existingDownloadUrl));
            }

            return xml.ToString();
        }
    }
}
