using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SchoolManagementWebApp.Models;
using System.Text;

namespace SchoolManagementWebApp.Controllers
{
    public class AdministratorController : Controller
    {
        HttpClient client;

        public AdministratorController()
        {
            HttpClientHandler clienthandler = new HttpClientHandler();
            clienthandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, SslPolicyErrors) => { return true; };
            client = new HttpClient(clienthandler);
        }
        public IActionResult AdministratorDashboard()
        {
            return View();
        }

        public IActionResult AddClass()
        {
            return View();
        }

        public IActionResult AddGuardian()
        {
            return View();
        }
        public IActionResult AdmitStudent()
        {
            return View();
        }

        public IActionResult AddSubjects()
        {
            return View();        
        }

        [HttpPost]
        public IActionResult AddSubjects(Subject sub)
        {
            string url = "https://localhost:7238/api/User/AddSubject";
            var jsondata = JsonConvert.SerializeObject(sub);
            StringContent stringContent = new StringContent(jsondata,Encoding.UTF8,"application/json");
            HttpResponseMessage response = client.PostAsync(url, stringContent).Result;
            if(response.IsSuccessStatusCode)
            {
                TempData["Msg"] = "Subject Added Succesfully";
                return RedirectToAction("AdministratorDashboard","Administrator");
            }
            else
            {
                TempData["Msg"] = "Something Went Wrong Please Try Again Later";
                return View();

            }
            
        }

        public IActionResult AddTeacher()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddTeacher(Teacher teacher)
        {
            string url = "https://localhost:7238/api/User/AddTeacher";
            var jsondata = JsonConvert.SerializeObject(teacher);
            StringContent stringContent = new StringContent(jsondata,Encoding.UTF8,"application/json");
            HttpResponseMessage response = client.PostAsync(url,stringContent).Result;
            if (response.IsSuccessStatusCode)
            {
                TempData["Msg"] = "Teacher Added Successfully";
                return RedirectToAction("AdministratorDashboard", "Administrator");
            }
            else
            {
                TempData["Msg"] = "Something Went Wrong please try again later";
                return View();
            }
            

        }
        public IActionResult FetchSubjects()
        {
            List<Subject> sub = new List<Subject>();
            string url = "https://localhost:7238/api/User/FetchAllSubjects";
            HttpResponseMessage response = client.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                var jsondata = response.Content.ReadAsStringAsync().Result;
                sub = JsonConvert.DeserializeObject<List<Subject>>(jsondata);
                return Json(sub); // Return data for the AJAX call
            }
            else
            {
                return Json(null); // Handle the error case
            }
        }

    }
}
