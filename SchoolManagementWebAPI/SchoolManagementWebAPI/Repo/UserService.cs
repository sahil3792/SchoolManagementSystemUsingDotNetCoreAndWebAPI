using Microsoft.AspNetCore.Identity;
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
        public List<Teacher> GetAllTeachers()
        {
            var data = db.Teachers.FromSqlRaw($"exec FetchAllTeachers").ToList();
            return data;
        }

        public void AddGuardian(Guardian g)
        {
            db.Database.ExecuteSqlRaw($"exec AddGuardian '{g.GuardianId}','{g.Password}','{g.FirstName}','{g.LastName}','{g.Relationship}','{g.ContactNumber}','{g.Email}','{g.Address}'");
            var Urole = "Guardian";
            db.Database.ExecuteSqlRaw($"exec insertUser '{g.GuardianId}','{g.Password}','{Urole}'");
        }
        public List<Guardian> GetAllGuardian()
        {
            var data = db.Guardians.FromSqlRaw($"exec FetchAllGuardians").ToList();
            return data;
        }

        public List<Class> GetAllClass()
        {
            var data = db.Classes.FromSqlRaw($"exec FetchAllClasses").ToList();
            return data;
        }
        public void AddClass(Class c)
        {
            db.Database.ExecuteSqlRaw($"exec AddClass '{c.ClassName}','{c.TeacherCoordinatorId}'");
        }

        public void AddStudent(Student s)
        {
            s.EnrollmentDate = DateOnly.FromDateTime(DateTime.Now);
            db.Database.ExecuteSqlRaw($"exec AddStudent '{s.StudentId}','{s.Password}','{s.FirstName}','{s.MiddleName}','{s.LastName}','{s.DateOfBirth}','{s.Gender}','{s.Address}','{s.ContactNumber}','{s.Email}','{s.EnrollmentDate}','{s.GuardianId}','{s.ClassId}'");
            var urole = "Student";
            db.Database.ExecuteSqlRaw($"exec insertUser '{s.StudentId}','{s.Password}','{urole}'");
        }

        public void AddTimetable(Timetable tt)
        {
            db.Database.ExecuteSqlRaw($"exec AddTimetable '{tt.ClassId}','{tt.Day}','{tt.StartTime}','{tt.EndTime}','{tt.Subject}','{tt.TeacherId}'");
        }


        public void AddLibrarian(Librarian lb)
        {
            db.Database.ExecuteSqlRaw($"exec AddLibrarian '{lb.LibrarianId}','{lb.password}','{lb.FirstName}','{lb.LastName}'");
            var urole = "Librarian";
            db.Database.ExecuteSqlRaw($"exec insertUser '{lb.LibrarianId}','{lb.password}','{urole}'");
        }

    }
}
