using PodcastTracking.Data.Repository;
using PodcastTracking.Domain.Model;

namespace PodcastTracking.Data.EntityFramework.Repository
{
    public class PublisherRepository : Repository<Publisher>, IPublisherRepository
    {
        public PublisherRepository(PodcastTrackingContext context) : base(context)
        {

        }
    }
}
