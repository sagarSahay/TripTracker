namespace TripTracker.UI.ViewComponents
{
    using System.Threading.Tasks;
    using BackService.Models;
    using Microsoft.AspNetCore.Mvc;

    public class EditTripViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(Trip trip)
        {
           
            await Task.Delay(0);
            return  View<Trip>("Edit", trip);
        }
    }
}
