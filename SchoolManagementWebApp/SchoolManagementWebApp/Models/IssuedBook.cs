namespace SchoolManagementWebApp.Models
{
    public class IssuedBook
    {
        public int IssuedId { get; set; }
        public int Bookid { get; set; }
        public int Userid { get; set; }
        public DateOnly IssueDate { get; set; }
        public DateOnly ReturnDate { get; set; }
        public string Status { get; set; }
        public decimal LateFee { get; set; }
    }
}
