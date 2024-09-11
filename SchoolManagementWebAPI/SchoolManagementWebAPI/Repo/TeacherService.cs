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

        public List<Student> FetchAllStudentbyClassid(string teacherid)
        {
           var data =  db.Students.FromSqlRaw($"exec FetchAllStudentClassId '{teacherid}'").ToList();
           return data;
        }

        public List<TeacherLeave> FetchAllTeacherLeavesBasedOnTeacherId(string teacherid)
        {
            var data = db.TeachersLeaves.FromSqlRaw($"exec FetchAllTeacherLeavesBasedOnTeacherId '{teacherid}' ").ToList();
            return data;
        }

        public void AddTeacherLeave(TeacherLeave tl)
        {
            db.Database.ExecuteSqlRaw($"exec AddTeacherLeave '{tl.TeacherId}','{tl.Leavetype}','{tl.StartDate.ToString("yyyy-MM-dd")}','{tl.EndDate.ToString("yyyy-MM-dd")}','{tl.LeaveReason}','{tl.Status}'");
        }
    }
}
