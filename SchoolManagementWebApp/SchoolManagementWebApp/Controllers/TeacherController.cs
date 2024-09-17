using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SchoolManagementWebApp.Models;
using System.Text;

namespace SchoolManagementWebApp.Controllers
{
    public class TeacherController : Controller
    {
        HttpClient client;

        public TeacherController()
        {
            HttpClientHandler clienthandler = new HttpClientHandler();
            clienthandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, SslPolicyErrors) => { return true; };
            client = new HttpClient(clienthandler);
        }
        public IActionResult TeacherDashboard()
        {
            return View();
        }

        public IActionResult AddAttendance()
        {
            List<Student> students = new List<Student>();
            var teacherid = HttpContext.Session.GetString("Teacher");
            string url = $"https://localhost:7238/api/Teacher/FetchStudentByClassID/{teacherid}";
            HttpResponseMessage response = client.GetAsync(url).Result;
            if(response.IsSuccessStatusCode)
            {
                var jsondata = response.Content.ReadAsStringAsync().Result;
                students = JsonConvert.DeserializeObject<List<Student>>(jsondata);
                return View(students);

            }
            else
            {
                TempData["Msg"] = "Couldnt fetch student list Please write a compliant if the problem continues";
                return View();
            }
            
        }

        [HttpGet]
        public IActionResult ViewLeaves()
        {
            List<TeacherLeave> teacherLeaves = new List<TeacherLeave>();    
            var teacherid = HttpContext.Session.GetString("Teacher");
            string url = $"https://localhost:7238/api/Teacher/FetchTeachersLeavesBasedOnTeacherId/{teacherid}";
            HttpResponseMessage responseMessage = client.GetAsync(url).Result;
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsondata = responseMessage.Content.ReadAsStringAsync().Result;
                teacherLeaves = JsonConvert.DeserializeObject<List<TeacherLeave>>(jsondata);
                if(teacherLeaves.Count == 0)
                {
                    TempData["Msg"] = "No Leaves Applied ";
                    return View(teacherLeaves);
                }
                return View(teacherLeaves);

            }
            else
            {
                TempData["Msg"] = "No Leaves";
                return View();
            }
            
        }

        public IActionResult ApplyLeave()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ApplyLeave(TeacherLeave tl)
        {
            tl.TeacherId = HttpContext.Session.GetString("Teacher");
            tl.Status = "Pending";
            string url = "https://localhost:7238/api/Teacher/AddTeacherLeave";
            var jsondata = JsonConvert.SerializeObject(tl);
            StringContent content = new StringContent(jsondata,Encoding.UTF8,"application/json");
            HttpResponseMessage response = client.PostAsync(url, content).Result;
            if (response.IsSuccessStatusCode)
            {
                TempData["Msg"] = "Leave Applied Successfully";
                return RedirectToAction("ViewLeaves");
            }
            else
            {
                TempData["Msg"] = "Something Went Wrong";
                return RedirectToAction("ViewLeaves");
            }
            
        }

        [HttpPost]
        public IActionResult MarkStudentAttendance(string[] AttendanceList)
        {
            string url = $"https://localhost:7238/api/Teacher/AddStudentAttendance";
            var jsondata = JsonConvert.SerializeObject(AttendanceList);
            StringContent content = new StringContent (jsondata,Encoding.UTF8,"application/json");
            HttpResponseMessage response = client.PostAsync (url, content).Result;
            if(response.IsSuccessStatusCode)
            {
                TempData["Msg"] = "Attendance Added Successfully";
                return RedirectToAction("AddAttendance");
            }
            else
            {
                TempData["Msg"] = "Couldnt Add Attendance Please try again";
                return RedirectToAction("AddAttendance");
            }

        }

        public IActionResult ViewStudents()
        {
            List<Student> students = new List<Student>();
            var teacherid = HttpContext.Session.GetString("Teacher");
            string url = $"https://localhost:7238/api/Teacher/FetchStudentByClassID/{teacherid}";
            HttpResponseMessage response = client.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                var jsondata = response.Content.ReadAsStringAsync().Result;
                students = JsonConvert.DeserializeObject<List<Student>>(jsondata);
                return View(students);

            }
            else
            {
                TempData["Msg"] = "Couldnt fetch student list Please write a compliant if the problem continues";
                return View();
            }

            
        }

        public IActionResult AddGradeRecord(string id)
        {
            ViewBag.StudentId = id;
            return View();
        }

        public IActionResult FetchSubjects(string id)
        {
            List<Subject> subjects = new List<Subject>();   
            string url = $"https://localhost:7238/api/Teacher/FetchAllSubjectsByStudentid/{id}";
            HttpResponseMessage res= client.GetAsync (url).Result;
            if (res.IsSuccessStatusCode)
            {
                var jsondata =res.Content.ReadAsStringAsync().Result;
                subjects = JsonConvert.DeserializeObject<List<Subject>>(jsondata);
                return Json(subjects);

            }
            else
            {
                TempData["Msg"] = "Couldnt Fetch Subject Please try again later";
                return RedirectToAction("AddGradeRecord");
            }

                
            return Json(subjects);
        }


    }
}
