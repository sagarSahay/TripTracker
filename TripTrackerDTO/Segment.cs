namespace TripTrackerDTO
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Segment
    {
        public int Id { get; set; }

        [Required]
        public int TripId { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public DateTimeOffset StartDateTime { get; set; }

        [Required]
        public DateTimeOffset EndDateTime { get; set; }
    }
}
