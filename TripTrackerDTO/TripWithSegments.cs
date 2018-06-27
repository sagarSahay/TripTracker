namespace TripTracker.BackService.Models
{
    using System.Collections.Generic;
    using TripTrackerDTO;

    public class TripWithSegments : Trip
    {
        public ICollection<Segment> Segments { get; set; }
    }
}
