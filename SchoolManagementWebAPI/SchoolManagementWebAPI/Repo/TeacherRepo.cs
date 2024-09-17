using SchoolManagementWebAPI.Models;

namespace SchoolManagementWebAPI.Repo
{
    public interface TeacherRepo
    {

        public List<Student> FetchAllStudentbyClassid(string teacherid);

        public List<TeacherLeave> FetchAllTeacherLeavesBasedOnTeacherId(string teacherid);

        public void AddTeacherLeave(TeacherLeave tl);

        public void AddStudentAttendance(string[] attendancelist);

        public List<Subject> FetchAllSubjectByStudentid(string studentid);

        public int AddStudentMarks(StudentMarks sm);
        
    }
}
