namespace SchoolManagementWebAPI.Models
{
    public class StudentMarks
    {
        public int Id { get; set; }
        public string StudentId { get; set; }
        public string SubjectId { get; set; }
        public decimal Marks { get; set; }
    }
}
