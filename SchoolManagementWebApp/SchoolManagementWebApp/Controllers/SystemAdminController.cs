using Microsoft.AspNetCore.Mvc;

namespace SchoolManagementWebApp.Controllers
{
    public class SystemAdminController : Controller
    {
        public IActionResult AdminDashboard()
        {
            return View();
        }
    }
}
