using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TripTracker.BackService.Models;

namespace TripTracker.UI.Pages.Trips
{
    using Microsoft.AspNetCore.Authorization;
    using Services;

    [Authorize]
    public class EditModel : PageModel
    {
        private IApiClient context;

        public EditModel(IApiClient context)
        {
            this.context = context;
        }

        [BindProperty]
        public Trip Trip { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Trip = await context.GetTripAsync(id.Value);

            if (Trip == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await context.PutTripsAsync(Trip);

            return RedirectToPage("./Index");
        }
    }
}
