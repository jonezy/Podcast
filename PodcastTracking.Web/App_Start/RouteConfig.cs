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
                defaults: new { controller = "download", action="track", urlToTrack = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "PodcastList",
                url: "podcast/all",
                defaults: new { controller = "podcast", action="all"}
            );
            routes.MapRoute(
                name: "PodcastDetails",
                url: "podcast/{id}",
                defaults: new { controller = "podcast", action="index"}
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "home", action = "index", id = UrlParameter.Optional }
            );
        }
    }
}
