using System.ComponentModel.DataAnnotations;

namespace SchoolManagementWebApp.Models
{
    public class LibraryCard
    {
        [Key]
        public int LibraryCardId { get; set; }
        public string UserId { get; set; }
        public DateOnly IssuedDate { get; set; }
        public string? CardNumber { get; set; }
        public string? Status { get; set; } // "Active", "Inactive", etc.
    }
}
