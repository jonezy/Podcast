using PodcastTracking.Data.Repository;
using PodcastTracking.Domain.Model;

namespace PodcastTracking.Data.EntityFramework.Repository
{
    public class PodcastRepository : Repository<Podcast>, IPodcastRepository
    {
        public PodcastRepository(PodcastTrackingContext context) : base(context)
        {

        }
    }
}
