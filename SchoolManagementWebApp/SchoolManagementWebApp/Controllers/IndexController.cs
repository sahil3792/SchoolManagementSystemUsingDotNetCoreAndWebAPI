using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SchoolManagementWebApp.Models;
using System.Net.Security;
using System.Text;
using System.Text.Json.Serialization;
using static System.Net.WebRequestMethods;

namespace SchoolManagementWebApp.Controllers
{
    public class IndexController : Controller
    {
        HttpClient client;

        public IndexController()
        {
            HttpClientHandler clienthandler = new HttpClientHandler();
            clienthandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, SslPolicyErrors) => { return true; };
            client = new HttpClient(clienthandler); 
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(User u)
        {
            u.Urole = "empty";
            string url = "https://localhost:7238/api/User/AuthUser";
            var jsondata = JsonConvert.SerializeObject(u);
            StringContent content = new StringContent(jsondata, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(url, content).Result;
            if (response.IsSuccessStatusCode)
            {
                var responseData = response.Content.ReadAsStringAsync().Result;
                var authenticatedUser = JsonConvert.DeserializeObject<User>(responseData);

                // Redirect based on Urole
                if (authenticatedUser != null)
                {
                    if (authenticatedUser.Urole == "SystemAdmin")
                    {
                        return RedirectToAction("AdminDashboard", "Admin");
                    }
                    else if (authenticatedUser.Urole == "Employee")
                    {
                        return RedirectToAction("EmployeeDashboard", "Employee");
                    }
                    else if (authenticatedUser.Urole == "Manager")
                    {
                        return RedirectToAction("ManagerDashboard", "Manager");
                    }
                }
            }
            else
            {
                // Log the response for debugging
                var responseContent = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine($"API call failed with status code: {response.StatusCode}");
                Console.WriteLine($"Response content: {responseContent}");

                // Show error message to the user
                ViewBag.ErrorMessage = "Invalid credentials or an error occurred.";
            }
            return View();

            
        }
    }
}
