using System.Linq;
using System.Xml.Linq;

namespace PodcastTracking.Web.Application.Parsers
{
    public class BaseParser
    {
        protected XNamespace ITUNES = "http://www.itunes.com/dtds/podcast-1.0.dtd";
        protected XNamespace DC = "http://purl.org/dc/elements/1.1/";

        protected XElement GetChannel(XDocument xml)
        {
            var channel = (from c in xml.Descendants("channel") select c).SingleOrDefault();

            return channel;
        }
    }
}
