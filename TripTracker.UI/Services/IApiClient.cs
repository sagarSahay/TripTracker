using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TripTracker.BackService.Models;

namespace TripTracker.UI.Services
{
    public interface IApiClient
    {
        Task<List<Trip>> GetTripsAsync();

        Task<Trip> GetTripAsync(int id);

        Task PutTripsAsync(Trip tripToUpdate);

        Task AddTripAsync(Trip tripToAdd);
    }

    public class ApiClient : IApiClient
    {
        private readonly HttpClient httpClient;

        public ApiClient(HttpClient httpClient)
        {
            this.httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task AddTripAsync(Trip tripToAdd)
        {
            var response = await httpClient.PostJsonAsync("/api/Trips", tripToAdd);

            response.EnsureSuccessStatusCode();
        }

        public async Task<Trip> GetTripAsync(int id)
        {
            var response = await httpClient.GetAsync($"/api/Trips/{id}");

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsJsonAsync<Trip>();
        }

        public async Task<List<Trip>> GetTripsAsync()
        {
            var response = await httpClient.GetAsync("/api/Trips");

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsJsonAsync<List<Trip>>();
        }

        public async Task PutTripsAsync(Trip tripToUpdate)
        {
            var response = await httpClient.PutJsonAsync($"/api/Trips/{tripToUpdate.Id}", tripToUpdate);

            response.EnsureSuccessStatusCode();
        }
    }
}
