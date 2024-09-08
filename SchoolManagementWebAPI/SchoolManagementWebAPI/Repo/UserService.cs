using Microsoft.EntityFrameworkCore;
using SchoolManagementWebAPI.Data;
using SchoolManagementWebAPI.Models;

namespace SchoolManagementWebAPI.Repo
{
    public class UserService :UserRepo
    {
        private readonly ApplicationDbContext db;

        public UserService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public List<User> GetAllUser()
        {
            var data = db.Users.FromSqlRaw($"exec DisplayAllUsers").ToList();
            return data;
        }

        public User AuthUser(User u)
        {
            var data = db.Users.FromSqlRaw($" exec AuthUser '{u.UserId}','{u.Password}' ").AsEnumerable().SingleOrDefault();
            return data;
;        }

        public Administrator AddAdministrator(Administrator administrator)
        {
            db.Database.ExecuteSqlRaw($"exec AddAdministrator '{administrator.AdministratorUserId}','{administrator.Password}'");
            var data = db.Administrators.FromSqlRaw($"exec FetchAdministratorByUserId '{administrator.AdministratorUserId}'").AsEnumerable().SingleOrDefault();
            return data;

        }

        public void AddUser(string userid,string pass,string Urole)
        {
            db.Database.ExecuteSqlRaw($"exec insertUser '{userid}','{pass}','{Urole}'");
        }
        public void AddSubjects(Subject sub)
        {
            db.Database.ExecuteSqlRaw($"exec AddSubjects '{sub.SubjectName}'");
        }

        public List<Subject> GetSubjects()
        {
            var data = db.Subjects.FromSqlRaw($"exec FetchAllSubjects").ToList();
            return data;
        }

        public void AddTeacher(Teacher teacher)
        {
            DateOnly HireDate = DateOnly.FromDateTime(DateTime.Now);
            db.Database.ExecuteSqlRaw($"exec AddTeacher '{teacher.TeacherUserId}','{teacher.Password}','{teacher.FirstName}','{teacher.LastName}','{teacher.Qualification}','{teacher.SubjectId}','{teacher.Email}','{HireDate}'");
            var Urole = "Teacher";
            var data = db.Database.ExecuteSqlRaw($"exec insertUser '{teacher.TeacherUserId}','{teacher.Password}','{Urole}'");
            
            
        }


    }
}
