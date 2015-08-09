using PodcastTracking.Domain.Model;
using System.Xml.Linq;

namespace PodcastTracking.Web.Application.Parsers
{
    public class PublisherParser : BaseParser, IFeedParser<Publisher>
    {
        public Publisher Parse(XDocument xml, string feedUrl)
        {
            var channel = GetChannel(xml);
            var publisher = new Publisher
            {
                Name = channel.Element(ITUNES + "author").Value,
                Website = channel.Element("link").Value
            };

            return publisher;
        }
    }
}
