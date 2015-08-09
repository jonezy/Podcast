using PodcastTracking.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace PodcastTracking.Web.Application.Parsers
{
    public class EpisodeParser : BaseParser, IMultipleFeedParser<Episode>
    {
        public List<Episode> Parse(XDocument xml, string feedUrl)
        {
            var channel = GetChannel(xml);

            IEnumerable<XElement> items =
                from episode in channel.Descendants("item")
                select episode;

            var episodes = new List<Episode>();
            foreach (var item in items)
            {
                episodes.Add(new Episode
                {
                    Title = item.Element("title").Value,
                    Description = item.Element("description").Value,
                    Author = item.Element(ITUNES + "author").Value,
                    PublishDate = DateTime.Parse(item.Element("pubDate").Value),
                    EpisodeUrl = item.Element("link").Value,
                    EpisodeDownloadUrl = item.Element("enclosure").Attribute("url").Value
                });
            }

            return episodes;
        }
    }
}