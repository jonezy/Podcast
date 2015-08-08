using PodcastTracking.Domain.Model;
using System.Linq;
using System.Xml.Linq;

namespace PodcastTracking.Web.Application.Services
{
    public class PublisherParser : IFeedParser<Publisher>
    {
        public Publisher Parse(XDocument xml, string feedUrl)
        {
            var channel = (from c in xml.Descendants("channel") select c).SingleOrDefault();

            XNamespace itunes = "http://www.itunes.com/dtds/podcast-1.0.dtd";
            var publisher = new Publisher
            {
                Name = channel.Element(itunes + "author").Value,
                Website = channel.Element("link").Value
            };

            return publisher;
        }
    }
}
