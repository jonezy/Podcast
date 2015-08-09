using Autofac;
using Autofac.Integration.Mvc;
using AutoMapper;
using PodcastTracking.Data.EntityFramework;
using PodcastTracking.Data.EntityFramework.Repository;
using PodcastTracking.Data.Repository;
using PodcastTracking.Domain.Model;
using PodcastTracking.Domain.Service;
using PodcastTracking.Web.Application.Parsers;
using PodcastTracking.Web.Application.Services;
using PodcastTracking.Web.Models;
using System.Configuration;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace PodcastTracking.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var container = RegisterDependencies();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            RegisterMappings();
        }

        private void RegisterMappings()
        {
            Mapper.CreateMap<Download, DownloadViewModel>();
            Mapper.CreateMap<Podcast, PodcastViewModel>();
            Mapper.CreateMap<Episode, EpisodeViewModel>().ForMember(dest => dest.DownloadCount, opt => opt.MapFrom(src => src.Downloads.Count));

            Mapper.AssertConfigurationIsValid();
        }

        private IContainer RegisterDependencies()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            builder.Register(c =>
            {
                var connectionString = ConfigurationManager.ConnectionStrings["PodcastTracking"].ConnectionString;
                var context = new PodcastTrackingContext(connectionString);
                context.Database.Initialize(false);

                return context;
            }).InstancePerRequest();

            builder.RegisterType<EpisodeRepository>().As<IEpisodeRepository>();
            builder.RegisterType<PodcastRepository>().As<IPodcastRepository>();
            builder.RegisterType<PublisherRepository>().As<IPublisherRepository>();
            builder.RegisterType<PodcastService>().As<IPodcastService>();

            builder.RegisterType<FeedLoader>().As<IFeedLoader>();
            builder.RegisterType<EpisodeParser>().As<IMultipleFeedParser<Episode>>();
            builder.RegisterType<PodcastParser>().As<IFeedParser<Podcast>>();
            builder.RegisterType<PublisherParser>().As<IFeedParser<Publisher>>();

            builder.RegisterType<FeedImportingService>().As<IFeedImportingService>();
            builder.RegisterType<FeedGenerator>().As<IFeedGenerator>();
            builder.RegisterType<EpisodeService>().As<IEpisodeService>();

            return builder.Build();
        }

    }
}
