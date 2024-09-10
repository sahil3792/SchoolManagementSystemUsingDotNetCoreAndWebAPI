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
        public DbSet<Subject> Subjects { get; set; }    
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Guardian> Guardians { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Timetable> Timetables { get; set; }    
    }
}
