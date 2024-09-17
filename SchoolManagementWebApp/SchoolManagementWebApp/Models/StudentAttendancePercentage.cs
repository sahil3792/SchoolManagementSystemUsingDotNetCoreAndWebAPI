namespace SchoolManagementWebApp.Models
{
    public class StudentAttendancePercentage
    {
        public Student student { get; set; }

        public int PresentDays { get; set; }
        public int TotalDaysInMonth { get; set; }
        public double AttendancePercentage { get; set; }
    }
}
