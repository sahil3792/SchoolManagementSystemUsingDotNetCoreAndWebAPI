using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SchoolManagementWebApp.Models;

namespace SchoolManagementWebApp.Controllers
{
    public class GuardianController : Controller
    {
        HttpClient client;

        public GuardianController()
        {
            HttpClientHandler clienthandler = new HttpClientHandler();
            clienthandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, SslPolicyErrors) => { return true; };
            client = new HttpClient(clienthandler);
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GuardianDashboard()
        {
            return View();
        }

        [HttpGet]
        public IActionResult FeesPay()
        {
            var id = HttpContext.Session.GetString("Guardian");
            string url = $"https://localhost:7238/api/Guardian/GetFees/{id}";
            HttpResponseMessage response = client.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                var jsondata = response.Content.ReadAsStringAsync().Result;
                var Fess = JsonConvert.DeserializeObject<Class>(jsondata);
                return View(Fess);
            }
            else
            {
                return View();
            }

        }

        [HttpPost]
        public IActionResult InitiatePayment(string ClassName, string Id, double Fees)
        {
            try
            {
                // Initialize Razorpay client with API credentials
                var client = new Razorpay.Api.RazorpayClient("rzp_test_hyxzlMmdpXpNKr", "GWmkim1me8JM0XvpIucQwGCx");

                // Calculate amount in smallest currency unit (e.g., paise for INR)
                var paymentAmount = (int)(Fees * 100); // Convert to paise

                // Prepare options for order creation
                var options = new Dictionary<string, object>
        {
            { "amount", paymentAmount },
            { "currency", "INR" },
            { "receipt", Guid.NewGuid().ToString() },
            { "payment_capture", 1 } // Auto capture the payment
        };

                // Create the order
                var order = client.Order.Create(options);

                // Return the JSON response with the necessary data
                return Json(new
                {
                    key = "rzp_test_hyxzlMmdpXpNKr",
                    amount = paymentAmount,
                    ClassName = ClassName,
                    Id = Id,
                    orderId = order["id"].ToString() // Ensure you have the correct property name
                });
            }
            catch (Exception ex)
            {
                // Log exception and return error response
                // Consider using a logging framework or service
                return Json(new { success = false, message = "Error initiating payment: " + ex.Message });
            }
        }




    }
}
