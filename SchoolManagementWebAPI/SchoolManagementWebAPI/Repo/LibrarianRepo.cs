using SchoolManagementWebAPI.Models;

namespace SchoolManagementWebAPI.Repo
{
    public interface LibrarianRepo
    {

        List<Book> GetAllBooks();
        Book GetBookById(int id);
        void AddBook(Book book);
        void UpdateBook(Book book);
        void DeleteBook(int id);

        List<IssuedBook> GetAllIssuedBooks();
        IssuedBook GetIssuedBookById(int id);
        List<Book> GetBooks();
        List<User> GetUsers();
        void IssueBook(IssuedBook issuedBook);
        void ReturnBook(int id, string returnDate);
        decimal CalculateLateFee(int id, string returnDate);

        bool ReserveBook(int bookId, string userId);
        User GetUserById(int userId);
        List<User> GetAllUsers();

        LibraryCard GetLibraryCardById(int libraryCardId);
        List<LibraryCard> GetAllLibraryCards();

        void IssueLibraryCard(LibraryCard libraryCard);
        void UpdateLibraryCard(LibraryCard libraryCard);
    }
}
