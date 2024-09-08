using Microsoft.EntityFrameworkCore;
using SchoolManagementWebAPI.Data;
using SchoolManagementWebAPI.Models;

namespace SchoolManagementWebAPI.Repo
{
    public class AdministratorService
    {
        private readonly ApplicationDbContext db;
        public AdministratorService(ApplicationDbContext db)
        {
            this.db = db;
        }
        
    }
}
