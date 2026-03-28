using TrackingService.Data;
using TrackingService.Models;

namespace TrackingService.Repository
{
    public class TrackingRepository : ITrackingRepository
    {
        private readonly TrackingServiceContext _context;

        public TrackingRepository(TrackingServiceContext context)
        {
            _context = context;
        }

        public List<GpsTracking> GetAll()
        {
            return _context.GpsTrackings.ToList();
        }

        public void Add(GpsTracking gps)
        {
            _context.GpsTrackings.Add(gps);
            _context.SaveChanges();
        }

    }
}
