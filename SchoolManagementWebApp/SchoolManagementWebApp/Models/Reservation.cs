namespace SchoolManagementWebApp.Models
{
    public class Reservation
    {
        public int ReservationId { get; set; }
        public int BookId { get; set; }
        public string UserId { get; set; }
        public DateOnly? ReservationDate { get; set; }
        public string? Status { get; set; }
    }
}
