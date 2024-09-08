namespace SchoolManagementWebApp.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string TeacherUserId { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Qualification { get; set; }
        public int  SubjectId {  get; set; }
        public string Email { get; set; }
        public DateOnly HireDate { get; set; }  

    }
}
