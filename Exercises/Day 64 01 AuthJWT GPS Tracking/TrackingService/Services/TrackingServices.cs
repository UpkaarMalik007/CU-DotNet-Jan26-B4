using TrackingService.DTOs;
using TrackingService.Models;
using TrackingService.Repository;

namespace TrackingService.Services
{
    public class TrackingServices: ITrackingServices
    {
        private readonly ITrackingRepository _repo;

        public TrackingServices(ITrackingRepository repo)
        {
            _repo = repo;
        }

        public List<GpsTrackingDto> GetAll()
        {
            var data = _repo.GetAll();

            return data.Select(x => new GpsTrackingDto
            {
                TruckId = x.TruckId,
                Location = x.Location,
                Timestamp = x.Timestamp
            }).ToList();
        }

        public void Add(CreateGpsDto dto)
        {
            var random = new Random();

            // Random Latitude: -90 to +90
            double latitude = random.NextDouble() * 180 - 90;

            // Random Longitude: -180 to +180
            double longitude = random.NextDouble() * 360 - 180;

            var gps = new GpsTracking
            {
                TruckId = dto.TruckId,
                Location = $"{latitude:F6},{longitude:F6}",
                Timestamp = DateTime.UtcNow
            };

            _repo.Add(gps);
        }


    }
}
