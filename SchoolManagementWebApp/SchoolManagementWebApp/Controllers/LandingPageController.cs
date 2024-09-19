using Microsoft.AspNetCore.Mvc;

namespace SchoolManagementWebApp.Controllers
{
    public class LandingPageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
