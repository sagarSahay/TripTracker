using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TripTracker.BackService.Models;
using TripTracker.UI.Data;

namespace TripTracker.UI.Pages.Trips
{
    using Services;

    public class DeleteModel : PageModel
    {
        private IApiClient context;

        public DeleteModel(IApiClient context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Trip = await context.GetTripAsync(id.Value);

            if (Trip != null)
            {
                await context.RemoveTripAsync(id.Value);
            }

            return RedirectToPage("./Index");
        }
    }
}
