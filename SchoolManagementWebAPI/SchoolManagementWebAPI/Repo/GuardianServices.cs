using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using SchoolManagementWebAPI.Data;
using SchoolManagementWebAPI.Models;

namespace SchoolManagementWebAPI.Repo
{
    public class GuardianServices : GuardianRepo
    {
        private readonly ApplicationDbContext db;

        public GuardianServices(ApplicationDbContext db)
        {
            this.db = db;
        }

        public Class FessPayGet(string id)
        {
            var data = db.Classes.FromSqlRaw($"Exec GetFees {id}").AsEnumerable().SingleOrDefault();
            return data;
        }
    }
}
