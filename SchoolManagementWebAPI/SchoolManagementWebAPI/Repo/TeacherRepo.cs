using SchoolManagementWebAPI.Models;

namespace SchoolManagementWebAPI.Repo
{
    public interface TeacherRepo
    {

        public List<Student> FetchAllStudentbyClassid(int teacherid);
    }
}
