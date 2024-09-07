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

    }
}
