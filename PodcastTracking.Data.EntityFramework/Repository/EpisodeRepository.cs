using PodcastTracking.Data.Repository;
using PodcastTracking.Domain.Model;

namespace PodcastTracking.Data.EntityFramework.Repository
{
    public class EpisodeRepository : Repository<Episode>, IEpisodeRepository
    {
        public EpisodeRepository(PodcastTrackingContext context) : base(context)
        {

        }
    }
}
