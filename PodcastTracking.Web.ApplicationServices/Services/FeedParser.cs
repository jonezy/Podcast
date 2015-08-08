using PodcastTracking.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace PodcastTracking.Web.Application.Services
{
    public interface IFeedParser<T>
    {
        T Parse(XDocument xml, string feedUrl);
    }

    public class FeedParser : IFeedParser<Publisher>
    {
        public Publisher Parse(XDocument xml, string feedUrl)
        {
            var channel = (from c in xml.Descendants("channel") select c).SingleOrDefault();
            var podcast = new Podcast
            {
                Title = channel.Element("title").Value,
                FeedUrl = feedUrl,
                Link = channel.Element("link").Value,
                LastUpdated = DateTime.Now
            };

            IEnumerable<XElement> items =
                from episode in channel.Descendants("item")
                select episode;

            XNamespace dc = "http://purl.org/dc/elements/1.1/";
            XNamespace itunes = "http://www.itunes.com/dtds/podcast-1.0.dtd";
            foreach (var item in items)
            {
                podcast.Episodes.Add(new Episode
                {
                    Title = item.Element("title").Value,
                    Description = item.Element("description").Value,
                    Author = item.Element(itunes + "author").Value,
                    PublishDate = DateTime.Parse(item.Element("pubDate").Value),
                    EpisodeUrl = item.Element("link").Value,
                    EpisodeDownloadUrl = item.Element("enclosure").Attribute("url").Value
                });
            }

            var publisher = new Publisher
            {
                Name = channel.Element(itunes + "author").Value,
            };
            publisher.Podcasts.Add(podcast);

            return publisher;
        }
    }
}
