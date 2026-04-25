namespace TrackingService.DTOs
{
    public class GpsTrackingDto
    {
        public int TruckId { get; set; }
        public string Location { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
