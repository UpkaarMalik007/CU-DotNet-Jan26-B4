using TrackingService.DTOs;
using TrackingService.Models;

namespace TrackingService.Services
{
    public interface ITrackingServices
    {
        void Add(CreateGpsDto dto);
        List<GpsTrackingDto> GetAll();
    }
}
