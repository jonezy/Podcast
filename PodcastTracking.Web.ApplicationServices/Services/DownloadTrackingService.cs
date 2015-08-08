using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace PodcastTracking.Web.Application.Services
{
    public interface IDownloadTrackingService
    {
        void TrackEpisodeDownload(string episodeUrl, HttpRequestBase request);
    }

    public class DownloadTrackingService : IDownloadTrackingService
    {
        public DownloadTrackingService()
        {

        }

        public void TrackEpisodeDownload(string episodeUrl, HttpRequestBase request)
        {
                
        }
    }
}
