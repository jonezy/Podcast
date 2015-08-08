using System.Net;
using System.Xml;
using System.Xml.Linq;

namespace PodcastTracking.Web.Application.Services
{
    public interface IFeedLoader
    {
        XDocument Load(string feedUrl);
    }

    public class FeedLoader : IFeedLoader
    {
        public XDocument Load(string feedUrl)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(feedUrl);
            request.UserAgent = "PodcastTracking.Web";

            XDocument xml = new XDocument();
            using (var response = request.GetResponse())
            {
                using (var reader = XmlReader.Create(response.GetResponseStream()))
                {
                    xml = XDocument.Load(reader);
                }
            }

            return xml;
        }
    }
}
