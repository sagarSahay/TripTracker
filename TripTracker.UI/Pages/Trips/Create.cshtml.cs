using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TripTracker.BackService.Models;
using TripTracker.UI.Data;

namespace TripTracker.UI.Pages.Trips
{
    using Services;

    public class CreateModel : PageModel
    {
        private IApiClient context;

        public CreateModel(IApiClient context)
        {
            this.context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Trip Trip { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //_context.Trip.Add(Trip);
            //await _context.SaveChangesAsync();
            await context.AddTripAsync(Trip);

            return RedirectToPage("./Index");
        }
    }
}