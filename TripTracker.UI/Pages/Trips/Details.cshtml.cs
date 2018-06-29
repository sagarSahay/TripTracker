﻿using System;
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

    public class DetailsModel : PageModel
    {
        private IApiClient context;


        public DetailsModel(IApiClient context)
        {
            this.context = context;
        }

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
    }
}
