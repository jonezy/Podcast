using PodcastTracking.Domain.Model;
using System.Collections.Generic;
using System.Linq;

namespace PodcastTracking.Domain.Service
{
    public interface IEpisodeService
    {
        List<Episode> UpdateEpisodes(List<Episode> existingEpisodes, List<Episode> newEpisodes);
    }

    public class EpisodeService : IEpisodeService
    {
        public List<Episode> UpdateEpisodes(List<Episode> existingEpisodes, List<Episode> newEpisodes)
        {
            existingEpisodes = existingEpisodes.OrderByDescending(e => e.PublishDate).ToList();
            newEpisodes = newEpisodes.OrderByDescending(e => e.PublishDate).ToList();

            if (existingEpisodes.Count == newEpisodes.Count)
                return existingEpisodes;

            var lastPublishDate = existingEpisodes.Last().PublishDate;
            existingEpisodes.AddRange(newEpisodes.Where(e => e.PublishDate > lastPublishDate));

            return existingEpisodes;
        }
    }
}
