using TrackingService.Models;

namespace TrackingService.Repository
{
    public interface ITrackingRepository
    {
        void Add(GpsTracking gps);
        List<GpsTracking> GetAll();
    }
}
