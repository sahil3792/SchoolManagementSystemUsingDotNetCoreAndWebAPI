using Microsoft.EntityFrameworkCore;
using SchoolManagementWebAPI.Data;
using SchoolManagementWebAPI.Models;

namespace SchoolManagementWebAPI.Repo
{
    public class TeacherService:TeacherRepo
    {
        private readonly ApplicationDbContext db;
        public TeacherService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public List<Student> FetchAllStudentbyClassid(int teacherid)
        {
           var data =  db.Students.FromSqlRaw($"exec FetchAllStudentClassId '{teacherid}'").ToList();
           return data;
        }
    }
}
