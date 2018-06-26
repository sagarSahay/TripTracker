using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TripTracker.BackService.Models;

namespace TripTracker.BackService.Controllers
{
    [Route("api/[controller]")]
    public class TripsController : Controller
    {
        private Repository repository;

        public TripsController(Repository repository)
        {
            this.repository = repository ?? throw new ArgumentException(nameof(repository));
        }

        // GET api/trips
        [HttpGet]
        public IEnumerable<Trip> Get()
        {
            return repository.Get();
        }

        // GET api/trips/5
        [HttpGet("{id}")]
        public Trip Get(int id)
        {
            return repository.Get(id);
        }

        // POST api/trips
        [HttpPost]
        public void Post([FromBody]Trip value)
        {
            repository.Add(value);
        }

        // PUT api/trips/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Trip value)
        {
            repository.Update(value);
        }

        // DELETE api/trips/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            repository.Remove(id);
        }
    }
}
