using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SchoolManagementWebApp.Models;
using System.Text;

namespace SchoolManagementWebApp.Controllers
{
    public class LibrarianController : Controller
    {
        HttpClient client;

        public LibrarianController()
        {
            HttpClientHandler clienthandler = new HttpClientHandler();
            clienthandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, SslPolicyErrors) => { return true; };
            client = new HttpClient(clienthandler);
        }
        public IActionResult LibrarianDashboard()
        {
            return View();
        }

        
        public IActionResult ViewBooks()
        {
            List<Book> books = new List<Book>();
            string url = "https://localhost:7238/api/Librarian/GetAllBooks";
            HttpResponseMessage response = client.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                var jsondata = response.Content.ReadAsStringAsync().Result;
                books = JsonConvert.DeserializeObject<List<Book>>(jsondata);
                return View(books);
            }
            else
            {
                return View();
            }
        }

        public IActionResult AddBooks()
        {
            return View();

            
        }

        [HttpPost]
        public IActionResult AddBooks(Book b)
        {
            string url = "https://localhost:7238/api/Librarian/AddBooks";
            var jsondata = JsonConvert.SerializeObject(b);
            StringContent stringContent = new StringContent(jsondata,Encoding.UTF8,"application/json");
            HttpResponseMessage res = client.PostAsync(url, stringContent).Result;
            if(res.IsSuccessStatusCode)
            {
                TempData["Msg"] = "Book Added Successfully";
                return RedirectToAction("ViewBooks");
            }
            else
            {
                TempData["Msg"] = "Something Went Wrong Please try again later";
                return View();
            }
        }

        public IActionResult IssueBook()
        {
            return View();
        }

        public IActionResult ReservedBooks()
        {
            return View();  
        }

        public IActionResult GenerateCard()
        {
            return View();
        }
    }
}
