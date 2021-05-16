using ApplicationCore.Entity.Identity;
using Microsoft.EntityFrameworkCore;
using StudentInfo.Entity.Entity;
using System.Reflection;

namespace StudentInfo.DataAccess.EF.Concrete.Context
{
    public class StudentInfoDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("Server=104.131.162.10; Port=3306; Database=VBS;Uid=root;Pwd=root; ConvertZeroDateTime=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Parent> Parents { get; set; }
        public DbSet<StudentTeacher> StudentTeachers { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<HomeWork> HomeWorks { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Meet> Meets { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<AppClaim> AppClaims { get; set; }
        public DbSet<AppUserClaim> AppUserClaims { get; set; }
    }
}
