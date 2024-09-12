namespace SchoolManagementWebApp.Models
{
    public class StudentAttendance
    {
        public int Id { get; set; }
        public string StudentId { get; set; }
        public DateOnly AttendanceDate { get; set; }
        public bool Attendance { get; set; }
    }
}
