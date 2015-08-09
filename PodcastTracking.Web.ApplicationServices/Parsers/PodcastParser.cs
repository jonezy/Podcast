using PodcastTracking.Domain.Model;
using System;
using System.Xml.Linq;

namespace PodcastTracking.Web.Application.Parsers
{
    public class PodcastParser : BaseParser, IFeedParser<Podcast>
    {
        public Podcast Parse(XDocument xml, string feedUrl)
        {
            var channel = GetChannel(xml);
            var description = channel.Element("description").Value;
            if (description == null || description.Length == 0)
                description = channel.Element(ITUNES + "subtitle").Value;

            var podcast = new Podcast
            {
                Title = channel.Element("title").Value,
                Description = description,
                Category = channel.Element(ITUNES + "category").Attribute("text").Value,
                Image = channel.Element(ITUNES + "image").Attribute("href").Value,
                FeedUrl = feedUrl,
                Link = channel.Element("link").Value,
                LastUpdated = DateTime.Now
            };

            return podcast;
        }
    }
}
