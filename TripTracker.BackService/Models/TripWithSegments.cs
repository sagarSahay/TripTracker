namespace TripTracker.BackService.Models
{
    using System.Collections.Generic;

    public class TripWithSegments : TripTrackerDTO.Trip
    {
        public ICollection<Segment> Segments { get; set; }
    }
}
