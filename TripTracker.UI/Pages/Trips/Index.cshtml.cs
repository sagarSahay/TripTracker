using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TripTracker.BackService.Models;

namespace TripTracker.UI.Pages.Trips
{
    using Services;

    public class IndexModel : PageModel
    {
        private readonly IApiClient client;

        public IndexModel(IApiClient client)
        {
            this.client = client;
        }

        public IList<Trip> Trip { get;set; }

        public async Task OnGetAsync()
        {
            Trip = await client.GetTripsAsync();
        }
    }
}
