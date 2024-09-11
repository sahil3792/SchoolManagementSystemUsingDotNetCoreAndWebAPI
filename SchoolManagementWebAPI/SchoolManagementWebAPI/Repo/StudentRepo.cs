using SchoolManagementWebAPI.Models;

namespace SchoolManagementWebAPI.Repo
{
    public interface StudentRepo
    {
        public List<Timetable> FetchTimetableByStudentid(string studentid);
        
    }
}
