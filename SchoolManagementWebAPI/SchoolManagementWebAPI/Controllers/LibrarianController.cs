using Microsoft.AspNetCore.Mvc;
using SchoolManagementWebAPI.Models;
using SchoolManagementWebAPI.Repo;

namespace SchoolManagementWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibrarianController : ControllerBase
    {
        private readonly LibrarianRepo repo;
        
        public LibrarianController(LibrarianRepo repo)
        {
            this.repo = repo;
        }

        [Route("GetAllBooks")]
        [HttpGet]
        public IActionResult GetAllBooks()
        {
            var data = repo.GetAllBooks();
            if (data == null)
            {
                return null;
            }
            else
            {
                return Ok(data);
            }
            
        }

        [Route("AddBooks")]
        [HttpPost]
        public IActionResult AddBooks(Book b)
        {
            repo.AddBook(b);
            return Ok("successfully added book");
        }


    }
}
