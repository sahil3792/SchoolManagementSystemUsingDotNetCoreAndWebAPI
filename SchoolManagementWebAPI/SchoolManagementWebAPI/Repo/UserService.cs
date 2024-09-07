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

        

    }
}
