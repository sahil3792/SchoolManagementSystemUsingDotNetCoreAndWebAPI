using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SchoolManagementWebApp.Models;
using System.Text;

namespace SchoolManagementWebApp.Controllers
{
    public class SystemAdminController : Controller
    {
        HttpClient client;

        public SystemAdminController()
        {
            HttpClientHandler clienthandler = new HttpClientHandler();
            clienthandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, SslPolicyErrors) => { return true; };
            client = new HttpClient(clienthandler);
        }
        public IActionResult AdminDashboard()
        {
            return View();
        }

        public IActionResult AddAdministrator()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddAdministrator(Administrator administrator)
        {
            string url = "https://localhost:7238/api/User/AddAdministrator";
            var jsondata = JsonConvert.SerializeObject(administrator);
            StringContent stringContent = new StringContent(jsondata,Encoding.UTF8,"application/json");
            HttpResponseMessage response = client.PostAsync(url, stringContent).Result;
            if (response.IsSuccessStatusCode)
            {
                TempData["Msg"] = "Administrator Added Successfully";
                return RedirectToAction("AdminDashboard", "SystemAdmin");
            }
            else
            {
                TempData["Msg"] = "Something went wrong please try again";
                return View();
            }
            
        }
    }
}
