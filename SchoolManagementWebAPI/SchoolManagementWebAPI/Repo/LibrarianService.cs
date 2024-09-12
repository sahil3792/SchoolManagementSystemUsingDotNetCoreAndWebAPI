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
            var data = db.Books.FromSqlRaw("exec GetAllBooks ");
            if(data == null)
            {
                return null;
            }
            else
            {
                return data.ToList();
            }
            
        }

        public void AddBook(Book book)
        {
            db.Database.ExecuteSqlRaw($"exec AddBooks '{book.Title}','{book.AuthorName}','{book.ISBN}','{book.PublishedDate}','{book.NumberofCopies}'");

        }
    }
}
