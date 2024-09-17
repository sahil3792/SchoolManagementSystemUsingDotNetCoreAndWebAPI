namespace SchoolManagementWebAPI.Models
{
    public class TeacherAttendance
    {
        public int Id { get; set; }
        public string TeacherUserId {  get; set; }
        public DateOnly AttendanceDate { get; set; }
        public bool Attendance { get; set; }
    }
}
