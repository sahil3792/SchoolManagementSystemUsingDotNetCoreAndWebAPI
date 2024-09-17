using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SchoolManagementWebApp.Models;

namespace SchoolManagementWebApp.Controllers
{
    public class StudentController : Controller
    {
        HttpClient client;
        public StudentController() {
            HttpClientHandler clienthandler = new HttpClientHandler();
            clienthandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, SslPolicyErrors) => { return true; };
            client = new HttpClient(clienthandler);
        }
        public IActionResult StudentDashboard()
        {
            return View();
        }
        public IActionResult ViewTimetable()
        {
            List<Timetable> tt = new List<Timetable>();
            var Userid = HttpContext.Session.GetString("Student");
            string url = $"https://localhost:7238/api/Student/FetchTimetableBasedOnStudentId/{Userid}";
            HttpResponseMessage response = client.GetAsync(url).Result;
            if(response.IsSuccessStatusCode)
            {
                var jsondata = response.Content.ReadAsStringAsync().Result;
                tt = JsonConvert.DeserializeObject<List<Timetable>>(jsondata);
                return View(tt);

            }
            else
            {
                TempData["Msg"] = "Something Went Wrong Please Try Again Later";
                return View();
            }
            
        }

        
    }
}
