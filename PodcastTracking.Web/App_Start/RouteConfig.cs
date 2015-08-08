using System.Web.Mvc;
using System.Web.Routing;

namespace PodcastTracking.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "DownloadTracking",
                url: "download/track/{urlToTrack}",
                defaults: new { controller = "Download", action="Track", urlToTrack = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
