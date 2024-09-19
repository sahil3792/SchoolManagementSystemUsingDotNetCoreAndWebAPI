using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SchoolManagementWebApp.Models;
using System.Net.Security;
using System.Security.Claims;
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
                        var identity = new ClaimsIdentity(new[] {
                        new Claim(ClaimTypes.Name,u.UserId)},
                        CookieAuthenticationDefaults.AuthenticationScheme);
                        var principal = new ClaimsPrincipal(identity);
                        HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,principal);
                        HttpContext.Session.SetString("SystemAdmin",u.UserId);
                        return RedirectToAction("AdminDashboard","SystemAdmin" );
                    }
                    else if (authenticatedUser.Urole == "Administrator")
                    {
                        var identity = new ClaimsIdentity(new[] {
                        new Claim(ClaimTypes.Name,u.UserId)},
                        CookieAuthenticationDefaults.AuthenticationScheme);
                        var principal = new ClaimsPrincipal(identity);
                        HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                        HttpContext.Session.SetString("Administrator", u.UserId);
                        return RedirectToAction("AdministratorDashboard", "Administrator");
                    }
                    else if (authenticatedUser.Urole == "Teacher")
                    {
                        var identity = new ClaimsIdentity(new[] {
                        new Claim(ClaimTypes.Name,u.UserId)},
                        CookieAuthenticationDefaults.AuthenticationScheme);
                        var principal = new ClaimsPrincipal(identity);
                        HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                        HttpContext.Session.SetString("Teacher", u.UserId);
                        return RedirectToAction("TeacherDashboard", "Teacher");
                    }
                    else if (authenticatedUser.Urole == "Librarian")
                    {
                        var identity = new ClaimsIdentity(new[] {
                        new Claim(ClaimTypes.Name,u.UserId)},
                        CookieAuthenticationDefaults.AuthenticationScheme);
                        var principal = new ClaimsPrincipal(identity);
                        HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                        HttpContext.Session.SetString("Librarian", u.UserId);
                        return RedirectToAction("LibrarianDashboard", "Librarian");
                    }
                    else if (authenticatedUser.Urole == "Accountant")
                    {
                        var identity = new ClaimsIdentity(new[] {
                        new Claim(ClaimTypes.Name,u.UserId)},
                        CookieAuthenticationDefaults.AuthenticationScheme);
                        var principal = new ClaimsPrincipal(identity);
                        HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                        HttpContext.Session.SetString("Accountant", u.UserId);
                        return RedirectToAction("AccountantDashboard", "Accountant");
                    }
                    else if (authenticatedUser.Urole == "Guardian")
                    {
                        var identity = new ClaimsIdentity(new[] {
                        new Claim(ClaimTypes.Name,u.UserId)},
                        CookieAuthenticationDefaults.AuthenticationScheme);
                        var principal = new ClaimsPrincipal(identity);
                        HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                        HttpContext.Session.SetString("Guardian", u.UserId);
                        return RedirectToAction("GuardianDashboard", "Guardian");
                    }
                    else
                    {
                        var identity = new ClaimsIdentity(new[] {
                        new Claim(ClaimTypes.Name,u.UserId)},
                        CookieAuthenticationDefaults.AuthenticationScheme);
                        var principal = new ClaimsPrincipal(identity);
                        HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                        HttpContext.Session.SetString("Student", u.UserId);
                        return RedirectToAction("StudentDashboard", "Student");
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

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            var storedCookie = Request.Cookies.Keys;
            foreach( var cookie in storedCookie)
            {
                Response.Cookies.Delete(cookie);
            }
            return RedirectToAction("Index", "Index");
        }
    }
}
