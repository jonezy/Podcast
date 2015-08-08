using PodcastTracking.Domain.Model;
using System;
using System.Linq;
using System.Xml.Linq;

namespace PodcastTracking.Web.Application.Services
{
    public class PodcastParser : IFeedParser<Podcast>
    {
        public Podcast Parse(XDocument xml, string feedUrl)
        {
            var channel = (from c in xml.Descendants("channel") select c).SingleOrDefault();
            XNamespace itunes = "http://www.itunes.com/dtds/podcast-1.0.dtd";

            var podcast = new Podcast
            {
                Title = channel.Element("title").Value,
                Description = channel.Element(itunes + "subtitle").Value,
                FeedUrl = feedUrl,
                Link = channel.Element("link").Value,
                LastUpdated = DateTime.Now
            };

            return podcast;
        }
    }
}
