using System.Collections.Generic;
using System.Xml.Linq;

namespace PodcastTracking.Web.Application.Parsers
{
    public interface IFeedParser<T>
    {
        T Parse(XDocument xml, string feedUrl);
    }

    public interface IMultipleFeedParser<T>
    {
        List<T> Parse(XDocument xml, string feedUrl);
    }
}
