using Microsoft.EntityFrameworkCore;
using SchoolManagementWebAPI.Data;
using SchoolManagementWebAPI.Models;

namespace SchoolManagementWebAPI.Repo
{
    public class StudentService : StudentRepo
    {
        private readonly ApplicationDbContext db;
        public StudentService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public List<Timetable> FetchTimetableByStudentid(string studentid)
        {
            var data = db.Timetables.FromSqlRaw($"exec FetchTimetableByStudentid '{studentid}' ").ToList();
            return data;
        }
    }
}
