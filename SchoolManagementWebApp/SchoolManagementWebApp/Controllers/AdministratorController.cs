using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
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
        public IActionResult FetchTeachers()
        {
            List<Teacher> teacher = new List<Teacher>();
            string url = "https://localhost:7238/api/User/GetAllTeachers";
            HttpResponseMessage response = client.GetAsync(url).Result;
            if(response.IsSuccessStatusCode)
            {
                var jsondata = response.Content.ReadAsStringAsync().Result;
                teacher = JsonConvert.DeserializeObject<List<Teacher>>(jsondata);
                return Json(teacher);
            }
            else
            {
                TempData["Msg"]= "Couldn't Find Teachers please add teacher or contact System Admin";
                return RedirectToAction("AdministratorDashboard");
            }
        }

        public IActionResult FetchGuardian()
        {
            List<Guardian> guardian = new List<Guardian>();
            string url = "https://localhost:7238/api/User/FetchAllGuardians";
            HttpResponseMessage message = client.GetAsync(url).Result;
            if(message.IsSuccessStatusCode)
            {
                var jsondata = message.Content.ReadAsStringAsync().Result;
                guardian = JsonConvert.DeserializeObject<List<Guardian>>(jsondata);
                return Json(guardian);
            }
            else
            {
                TempData["Msg"] = "Couldn't Find Guardian Please add Guardian or Contact System Admin";
                return RedirectToAction("AdministratorDashboard");
            }
        }
        public IActionResult FetchClass()
        {
            List <Class> classes = new List<Class>();
            string url = "https://localhost:7238/api/User/FetchAllClasses";
            HttpResponseMessage message = client.GetAsync(url).Result;
            if(message.IsSuccessStatusCode)
            {
                var jsondata = message.Content.ReadAsStringAsync().Result;
                classes = JsonConvert.DeserializeObject<List<Class>>(jsondata);
                return Json(classes);
            }
            else
            {
                TempData["Msg"] = "Couldn't Find Classes Please add Class or Contact System Admin";
                return RedirectToAction("AdministratorDashboard");
            }
        }

        public IActionResult AddClass()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddClass(Class c)
        {
            string url = "https://localhost:7238/api/User/AddClass";
            var jsondata = JsonConvert.SerializeObject(c);
            StringContent content = new StringContent(jsondata,Encoding.UTF8,"application/json");
            HttpResponseMessage response = client.PostAsync(url, content).Result;
            if(response.IsSuccessStatusCode)
            {
                TempData["Msg"] = "Class Added Successfully";
                return RedirectToAction("AdministratorDashboard");
            }
            else
            {
                TempData["Msg"] = "Something Went Wrong please try again later or Contact the system Admin";
                return View();
            }
            
        }

        public IActionResult AddGuardian()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddGuardian(Guardian guardian)
        {
            string url = "https://localhost:7238/api/User/AddGuardian";
            var jsondata = JsonConvert.SerializeObject(guardian);
            StringContent content = new StringContent(jsondata, Encoding.UTF8, "application/json");
            HttpResponseMessage message = client.PostAsync(url, content).Result;
            if(message.IsSuccessStatusCode)
            {
                TempData["Msg"] = "Guardian Added Successfully";
                return RedirectToAction("AdministratorDashboard");
            }
            else
            {
                TempData["Msg"] = "Something went wrong.If error Continues then Contact SystemAdmin";
                return View();
            }
        }
        public IActionResult AdmitStudent()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AdmitStudent(Student s)
        {
            
            string url = "https://localhost:7238/api/User/AddStudent";
            var jsondata = JsonConvert.SerializeObject(s);
            StringContent content = new StringContent(jsondata, Encoding.UTF8, "application/json");
            HttpResponseMessage message = client.PostAsync(url, content).Result;
            if(message.IsSuccessStatusCode)
            {
                TempData["Msg"] = "Student Added Successfully";
                return RedirectToAction("AdministratorDashboard");

            }
            else
            {
                return View();

            }
            
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
        public IActionResult AddAttendance()
        {
            List<Teacher> teachers = new List<Teacher>();
            //var teacherid = HttpContext.Session.GetString("Teacher");
            string url = "https://localhost:7238/api/User/GetAllTeachers";
            HttpResponseMessage response = client.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                var jsondata = response.Content.ReadAsStringAsync().Result;
                teachers = JsonConvert.DeserializeObject<List<Teacher>>(jsondata);
                return View(teachers);

            }
            else
            {
                TempData["Msg"] = "Couldnt fetch student list Please write a compliant if the problem continues";
                return View();
            }
        }

        public IActionResult MarkTeacherAttendance(string[] AttendanceList)
        {
            string url = $"https://localhost:7238/api/User/AddTeacherAttendance/{AttendanceList}";
            var jsondata = JsonConvert.SerializeObject(AttendanceList);
            StringContent content = new StringContent(jsondata, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(url, content).Result;
            if (response.IsSuccessStatusCode)
            {
                TempData["Msg"] = "Attendance Added Successfully";
                return RedirectToAction("AdministratorDashboard");
            }
            else
            {
                TempData["Msg"] = "Couldnt Add Attendance Please try again";
                return RedirectToAction("AdministratorDashboard");
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

        public IActionResult AddTimetable()
        {
            return View();

        }

        [HttpPost]
        public IActionResult AddTimetable(Timetable tt)
        {
            string url = "https://localhost:7238/api/User/AddTimetable";
            var jsondata = JsonConvert.SerializeObject(tt);
            StringContent content = new StringContent(jsondata, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(url,content).Result;
            if (response.IsSuccessStatusCode)
            {
                TempData["Msg"] = "TimeTable Added Successfully";
                return RedirectToAction("AddTimetable");
            }
            else
            {
                TempData["Msg"] = "Couldn't add Timetable please try again";
                return View();
            }
            
        }

        public IActionResult AddLibrarian()
        {
            return View();

        }

        [HttpPost]
        public IActionResult AddLibrarian(Librarian lb)
        {
            string url = "https://localhost:7238/api/User/AddLibrarian";
            var jsondata = JsonConvert.SerializeObject(lb);
            StringContent content = new StringContent(jsondata, Encoding.UTF8, "application/json");
            HttpResponseMessage message = client.PostAsync(url,content).Result;
            if (message.IsSuccessStatusCode)
            {
                TempData["Msg"] = "Librarian Added Successfully";
                return RedirectToAction("AdministratorDashboard");
            }
            else
            {
                TempData["Msg"] = "Something Went Wrong";
                return View();
            }
        }

        public IActionResult ViewLeaveRequest()
        {
            List<TeacherLeave> list = new List<TeacherLeave>(); 
            string url = "https://localhost:7238/api/User/FetchAllTeacherRequest";
            HttpResponseMessage message = client.GetAsync(url).Result;
            if (message.IsSuccessStatusCode)
            {
                var jsondata = message.Content.ReadAsStringAsync().Result;
                list = JsonConvert.DeserializeObject<List<TeacherLeave>>(jsondata);
                return View(list);
            }
            else
            {
                TempData["Msg"] = "Something Went Wrong Please try Again Later";
                return View();
            }
        }

        public IActionResult ApprovetheRequest(int id)
        {
            
            string url = $"https://localhost:7238/api/User/ApprovetheLeaveRequest/{id}";
            
            HttpResponseMessage message = client.PutAsync(url, null).Result;
            if (message.IsSuccessStatusCode)
            {
                TempData["Msg"] = "Successfully Approved request";
                return RedirectToAction("ViewLeaveRequest");
            }
            else
            {
                return View();
            }

        }
        public IActionResult RejecttheRequest(int id)
        {

            string url = $"https://localhost:7238/api/User/RejecttheLeaveRequest/{id}";

            HttpResponseMessage message = client.PutAsync(url, null).Result;
            if (message.IsSuccessStatusCode)
            {
                TempData["Msg"] = "Successfully Rejected request";
                return RedirectToAction("ViewLeaveRequest");
            }
            else
            {
                return View();
            }

        }

    }
}
