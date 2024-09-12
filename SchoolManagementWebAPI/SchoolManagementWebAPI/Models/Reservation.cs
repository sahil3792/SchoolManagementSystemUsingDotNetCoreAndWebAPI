namespace SchoolManagementWebAPI.Models
{
    public class Reservation
    {
        
        public int ReservationId { get; set; }
        public int BookId { get; set; }
        public int UserId { get; set; }
        public DateOnly ReservationDate { get; set; }
        public string? Status { get; set; }
    }
}
