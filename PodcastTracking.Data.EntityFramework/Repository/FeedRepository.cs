using PodcastTracking.Data.Repository;
using PodcastTracking.Domain.Model;

namespace PodcastTracking.Data.EntityFramework.Repository
{
    public class FeedRepository : Repository<Feed>, IFeedRepository
    {
        public FeedRepository(PodcastTrackingContext context) : base(context)
        {

        }
    }
}
