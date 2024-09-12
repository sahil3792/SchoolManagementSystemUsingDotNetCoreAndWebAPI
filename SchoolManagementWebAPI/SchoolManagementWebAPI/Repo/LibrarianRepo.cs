using SchoolManagementWebAPI.Models;

namespace SchoolManagementWebAPI.Repo
{
    public interface LibrarianRepo
    {

        public List<Book> GetAllBooks();
        
        public void AddBook(Book book);
        //Book GetBookByid(int id);
        //void UpdateBook(Book book);
        //void DeleteBook(int id);
        //List<IssuedBook> GetAllIssuedBooks();
        //IssuedBook GetIssuedBookById(int id);
        //List<Book> GetBooks();
        //List<User> GetUsers();
        //void IssueBook(IssuedBook issuedBook);
        //void ReturnBook(int id, string returnDate);
        //decimal CalculateLateFee(int id, string returnDate);
        //bool ReserveBook(int bookId, int userId);
        //User GetUserById(int userId);
        //List<User> GetAllUsers();
    }
}
