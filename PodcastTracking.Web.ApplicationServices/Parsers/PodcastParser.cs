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
            var podcast = new Podcast
            {
                Title = channel.Element("title").Value,
                Description = channel.Element(ITUNES + "subtitle").Value,
                FeedUrl = feedUrl,
                Link = channel.Element("link").Value,
                LastUpdated = DateTime.Now
            };

            return podcast;
        }
    }
}
