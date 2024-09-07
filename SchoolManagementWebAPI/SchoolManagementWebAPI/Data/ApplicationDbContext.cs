using Microsoft.EntityFrameworkCore;
using SchoolManagementWebAPI.Models;

namespace SchoolManagementWebAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Administrator> Administrators { get; set; }    
    }
}
