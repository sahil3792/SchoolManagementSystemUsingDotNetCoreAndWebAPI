using Microsoft.EntityFrameworkCore;
using SchoolManagementWebAPI.Data;
using SchoolManagementWebAPI.Models;

namespace SchoolManagementWebAPI.Repo
{
    public class LibrarianService :LibrarianRepo
    {
        private readonly ApplicationDbContext db;

        public LibrarianService(ApplicationDbContext db)
        {
            this.db = db;
        }


        public List<Book> GetAllBooks()
        {
            var data = db.Books.FromSqlRaw($"exec GetAllBooks ").ToList();
            return data;
        }

        public Book GetBookById(int id)
        {
            var data = db.Books.FromSqlRaw($"exec GetBookById {id} ").ToList().SingleOrDefault();
            return data;
        }

        public void AddBook(Book book)
        {
            db.Database.ExecuteSqlRaw($"exec AddBooks '{book.Title}','{book.AuthorName}','{book.ISBN}','{book.PublishedDate.ToString("yyyy-MM-dd")}',{book.NumberofCopies}");


        }

        public void UpdateBook(Book book)
        {
            db.Database.ExecuteSqlRaw($"exec UpdateAll  {book.Id}, '{book.Title}','{book.AuthorName}','{book.ISBN}','{book.PublishedDate}',{book.NumberofCopies}");

        }

        public void DeleteBook(int id)
        {
            var data = db.Books.Find(id);
            if (data != null)
            {

                db.Books.Remove(data);
                db.SaveChanges();

            }
        }

        public decimal CalculateLateFee(int id, string returnDate)
        {
            var data = db.IssuedBooks.FromSqlRaw($"exec CalculateLateFee {id},'{returnDate}'").AsEnumerable()
                .Select(ib => ib.LateFee)
                .SingleOrDefault();
            return data;

        }

        public List<IssuedBook> GetAllIssuedBooks()
        {
            var data = db.IssuedBooks.FromSqlRaw($"exec GetAllIssuedBooks ").ToList();
            return data;
        }

        public IssuedBook GetIssuedBookById(int id)
        {
            var data = db.IssuedBooks.FromSqlRaw($"exec GetIssuedBookById {id} ").AsEnumerable().SingleOrDefault();
            return data;
        }

        public List<Book> GetBooks()
        {
            var data = db.Books.ToList();
            return data;
        }

        public List<User> GetUsers()
        {
            var data = db.Users.ToList();
            return data;
        }


        public void IssueBook(IssuedBook issuedBook)
        {
            db.Database.ExecuteSqlRaw($"exec IssueBook {issuedBook.BookId},{issuedBook.Userid},'{issuedBook.IssueDate.ToString("yyyy-MM-dd")}','{issuedBook.ReturnDate.ToString("yyyy-MM-dd")}',{issuedBook.LateFee}");
        }

        public void ReturnBook(int id, string returnDate)
        {
            db.Database.ExecuteSqlRaw($"exec ReturnBook {id},'{returnDate}'");
        }


        public List<User> GetAllUsers()
        {
            var data = db.Users.FromSqlRaw($"exec GetAllUsers ").ToList();
            return data;
        }



        public User GetUserById(int userId)
        {
            var data = db.Users.FromSqlRaw($"exec GetUserById {userId} ").ToList().SingleOrDefault();
            return data;
        }

        public bool ReserveBook(int bookId, string userId)
        {
            var book = GetBookById(bookId);
            if (book != null && book.NumberofCopies > 0)
            {
                Reservation newReservation = new Reservation()
                {
                    BookId = bookId,
                    UserId = int.Parse(userId),
                    ReservationDate = DateOnly.FromDateTime(DateTime.Now),
                    Status = "Reserved"
                };

                db.Reservations.Add(newReservation);
                book.NumberofCopies--;
                db.SaveChanges();

                return true;
            }
            return false;
        }



        public LibraryCard GetLibraryCardById(int libraryCardId)
        {
            var data = db.LibraryCards.FromSqlRaw($"exec GetLibraryCardById {libraryCardId} ").AsEnumerable().SingleOrDefault();

            return data;
        }

        public List<LibraryCard> GetAllLibraryCards()
        {

            var data = db.LibraryCards.FromSqlRaw($"exec GetAllLibraryCards ").ToList();
            return data;


        }



        public void IssueLibraryCard(LibraryCard libraryCard)
        {
            db.Database.ExecuteSqlRaw($"exec IssueLibraryCard '{libraryCard.UserId}','{libraryCard.IssuedDate.ToString("yyyy-MM-d")}',{libraryCard.CardNumber},'{libraryCard.Status}'");
        }

        public void UpdateLibraryCard(LibraryCard libraryCard)
        {
            db.Database.ExecuteSqlRaw($"exec UpdateLibraryCard '{libraryCard.UserId}','{libraryCard.IssuedDate.ToString("yyyy-MM-d")}',{libraryCard.CardNumber},'{libraryCard.Status}' ");
        }
    }
}
