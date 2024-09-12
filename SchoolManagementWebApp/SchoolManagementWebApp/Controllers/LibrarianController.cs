using Microsoft.AspNetCore.Mvc;

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

        public IActionResult Addbooks()
        {
            string url = "";


            return View();
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
