using Microsoft.AspNetCore.Mvc;

namespace SchoolManagementWebApp.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult StudentDashboard()
        {
            return View();
        }
        public IActionResult ViewTimetable()
        {
            return View();
        }
    }
}
