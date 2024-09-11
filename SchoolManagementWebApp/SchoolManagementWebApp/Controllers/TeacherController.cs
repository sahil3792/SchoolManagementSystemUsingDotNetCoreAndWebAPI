using Microsoft.AspNetCore.Mvc;

namespace SchoolManagementWebApp.Controllers
{
    public class TeacherController : Controller
    {
        public IActionResult TeacherDashboard()
        {
            return View();
        }

        public IActionResult AddAttendance()
        {
            var teacherid = HttpContext.Session.GetString("Teacher");
            string url = $"https://localhost:7238/api/Teacher/FetchAllStudents/{teacherid}";
            return View();
        }
    }
}
