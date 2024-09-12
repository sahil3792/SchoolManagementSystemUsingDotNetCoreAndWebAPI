namespace SchoolManagementWebAPI.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string AuthorName { get; set; }
        public string ISBN { get; set; }
        public DateOnly PublishedDate { get; set; }
        public int NumberofCopies { get; set; }
    }
}
