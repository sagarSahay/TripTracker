using Microsoft.AspNetCore.Mvc;

namespace TripTracker.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController : Controller
    {
        public string Index()
        {
            return "Hello from the admin area";
        }
    }
}