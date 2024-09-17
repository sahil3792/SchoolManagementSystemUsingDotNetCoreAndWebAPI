using Microsoft.AspNetCore.Mvc;
using SchoolManagementWebAPI.Models;

namespace SchoolManagementWebAPI.Repo
{
    public interface StudentRepo
    {
        public List<Timetable> FetchTimetableByStudentid(string studentid);
        public StudentAttendancePercentage GetStudentData(string id);


    }
}
