using System;
using Microsoft.AspNetCore.Mvc;
using TripTracker.BackService.Models;

namespace TripTracker.BackService.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;
    using Data;
    using Microsoft.EntityFrameworkCore;

    [Route("api/[controller]")]
    public class TripsController : Controller
    {
        private TripContext context;

        public TripsController(TripContext context)
        {
            this.context = context ?? throw new ArgumentException(nameof(context));
            this.context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        // GET api/trips
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var trips = await context.Trips
                .AsNoTracking()
                .Include(t => t.Segments)
                .Select(t => new TripWithSegments
                {
                    Id = t.Id,
                    Name = t.Name,
                    StartDate = t.StartDate,
                    EndDate = t.EndDate,
                    Segments = t.Segments
                })
                .ToListAsync();

            return Ok(trips);
        }

        // GET api/trips/5
        [HttpGet("{id}")]
        public TripWithSegments Get(int id)
        {
            return context.Trips.Select(t => new TripWithSegments
            {
                Id = t.Id,
                Name = t.Name,
                StartDate = t.StartDate,
                EndDate = t.EndDate,
                Segments = t.Segments
            }).SingleOrDefault(t => t.Id == id);
        }

        // POST api/trips
        [HttpPost]
        public IActionResult Post([FromBody]Trip value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            context.Trips.Add(value);
            context.SaveChanges();

            return Ok();
        }

        // PUT api/trips/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody]Trip value)
        {
            if (context.Trips.Any(t => t.Id == id))
            {
                return NotFound();
            }
            context.Update(value);
            await context.SaveChangesAsync();

            return Ok();
        }

        // DELETE api/trips/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var myTrip = context.Trips.Find(id);

            if (myTrip == null)
            {
                return NotFound();
            }
            context.Trips.Remove(myTrip);
            context.SaveChanges();

            return NoContent();
        }
    }
}
