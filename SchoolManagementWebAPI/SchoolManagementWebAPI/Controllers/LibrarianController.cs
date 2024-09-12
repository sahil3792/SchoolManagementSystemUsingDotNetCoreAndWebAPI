using Microsoft.AspNetCore.Mvc;

namespace SchoolManagementWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibrarianController : ControllerBase
    {
        
        public LibrarianController()
        {

        }
        public IActionResult Index()
        {
            return Ok();
        }
    }
}
