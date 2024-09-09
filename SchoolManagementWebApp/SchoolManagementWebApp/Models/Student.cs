namespace SchoolManagementWebApp.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string StudentId { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }  
        public string LastName { get; set; }
        public DateOnly DateOfBirth { get; set; }   
        public string Gender { get; set; }  
        public string Address { get; set; }
        public string ContactNumber { get; set; }   
        public string Email {  get; set; }  
        public DateOnly EnrollmentDate { get; set; }
        public int GuardianId { get; set; }
        public int ClassId { get; set; }

    }
}
