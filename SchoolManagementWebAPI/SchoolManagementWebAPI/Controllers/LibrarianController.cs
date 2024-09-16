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


        [Route("GetBookById/{id}")]
        [HttpGet]
        public IActionResult GetBook(int id)
        {
            var book = repo.GetBookById(id);
            if (book == null)
            {
                return NotFound("Book not found");
            }
            return Ok(book);
        }

        //[Route("AddBooks")]
        //[HttpPost]
        //public IActionResult AddBook(Book b)
        //{
        //    repo.AddBook(b);

        //    return Ok("Book added Successfully");
        //}






        [Route("UpdateBook/{id}")]
        [HttpPut]
        public IActionResult UpdateBook(int id, Book b)
        {
            if (id != b.Id)
            {
                return BadRequest();
            }
            else
            {
                repo.UpdateBook(b);
                return Ok("Book updated successfully");

            }
        }



        [Route("DeleteBook/{id}")]
        [HttpDelete]
        public IActionResult DeleteBook(int id)
        {
            var d = repo.GetBookById(id);
            if (d == null)
            {
                return NotFound("Book not found");
            }

            repo.DeleteBook(id);
            return Ok("Book deleted successfully");
        }
        [Route("GetAllIssuedBooks")]
        [HttpGet]
        public IActionResult GetAllIssuedBooks()
        {
            var d = repo.GetAllIssuedBooks();
            return Ok(d);
        }

        [Route("GetIssuedBookById/{id}")]
        [HttpGet]
        public IActionResult GetIssuedBookById(int id)
        {
            var b = repo.GetIssuedBookById(id);
            if (b == null)
            {
                return NotFound("Book not found");
            }
            return Ok(b);
        }


        [Route("GetBooks")]
        [HttpGet]
        public IActionResult GetBooks()
        {
            var books = repo.GetBooks();


            return Ok(books);
        }

        [Route("GetUsers")]
        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = repo.GetUsers();


            return Ok(users);
        }



        [Route("IssueBookAdd")]
        [HttpPost]
        public IActionResult IssueBook(IssuedBook issuedBook)
        {
            repo.IssueBook(issuedBook);

            return Ok("Book issued successfully");
        }




        [Route("Return/{id}")]
        [HttpPut]
        public ActionResult ReturnBook(int id, string returnDate)
        {
            repo.ReturnBook(id, returnDate);
            return Ok(new { message = "Book returned successfully" });
        }

        [Route("late/{id}")]
        [HttpGet]
        public ActionResult<decimal> CalculateLateFee(int id, string returnDate)
        {
            var lateFee = repo.CalculateLateFee(id, returnDate);
            return Ok(lateFee);
        }


        [Route("GetUser")]
        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var d = repo.GetAllUsers();
            return Ok(d);
        }


        [Route("GetUserById/{id}")]
        [HttpGet]
        public IActionResult GetUserById(int id)
        {
            var user = repo.GetUserById(id);
            if (user == null)
            {
                return NotFound("user not found");
            }
            return Ok(user);
        }


        [Route("ReserveBook1")]
        [HttpPost]
        public IActionResult ReserveBook(Reservation rev)
        {
            //var result = repo.ReserveBook(bookId, userId);
            //if (result)
            //{
            //    return Ok(new { Message = "Book Reserved Successfully" });
            //}
            return Ok();
        }


        [Route("GetAllLibraryCards")]
        [HttpGet]
        public IActionResult GetAllLibraryCards()
        {
            var d = repo.GetAllLibraryCards();
            return Ok(d);
        }



        [Route("GetLibraryCardById/{id}")]
        [HttpGet]
        public IActionResult GetLibrary(int id)
        {
            var book = repo.GetLibraryCardById(id);
            if (book == null)
            {
                return NotFound("card not found");
            }
            return Ok(book);
        }

        //[Route("IssueLibraryCard")]
        //[HttpPost]
        //public IActionResult IssueLibraryCardAdd(Labirarycard libraryCard)
        //{
        //    if (libraryCard == null)
        //    {
        //        return BadRequest("Invalid data.");
        //    }

        //    repo.IssueLibraryCard(libraryCard);
        //    return Ok("Issue card added successfully");
        //}






        [Route("UpdateLibraryCard/{id}")]
        [HttpPut]
        public IActionResult UpdateLibraryCard(LibraryCard libraryCard)
        {
            //repo.UpdateBook(libraryCard);
            return Ok("Book updated successfully");
        }

    }
}
