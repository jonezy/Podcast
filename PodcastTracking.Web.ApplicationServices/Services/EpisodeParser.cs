using PodcastTracking.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace PodcastTracking.Web.Application.Services
{
    public class EpisodeParser : IMultipleFeedParser<Episode>
    {
        public List<Episode> Parse(XDocument xml, string feedUrl)
        {
            var channel = (from c in xml.Descendants("channel") select c).SingleOrDefault();

            IEnumerable<XElement> items =
                from episode in channel.Descendants("item")
                select episode;
            var episodes = new List<Episode>();

            XNamespace dc = "http://purl.org/dc/elements/1.1/";
            XNamespace itunes = "http://www.itunes.com/dtds/podcast-1.0.dtd";
            foreach (var item in items)
            {
                episodes.Add(new Episode
                {
                    Title = item.Element("title").Value,
                    Description = item.Element("description").Value,
                    Author = item.Element(itunes + "author").Value,
                    PublishDate = DateTime.Parse(item.Element("pubDate").Value),
                    EpisodeUrl = item.Element("link").Value,
                    EpisodeDownloadUrl = item.Element("enclosure").Attribute("url").Value
                });
            }

            return episodes;
        }
    }
}
