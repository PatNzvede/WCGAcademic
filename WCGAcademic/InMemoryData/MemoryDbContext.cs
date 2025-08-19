using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.EntityFrameworkCore;

namespace WCGAcademic.InMemoryData
{
    public class MemoryDbContext : DbContext

    {
        public MemoryDbContext(DbContextOptions<MemoryDbContext> options): base(options) 
        {
           
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().HasData(
                new Course { Id = 1, Name = "Accounting", CourseCode = "Acc101" },
                new Course { Id = 2, Name = "Balancing", CourseCode = "Bal101" });
        }
        public DbSet<Person> People => Set <Person>(); 
        public DbSet<Course> Courses => Set <Course>();
        public DbSet<CourseRegister> CourseRegisters => Set <CourseRegister>();
        public DbSet<Lecturer>  Lecturers => Set <Lecturer>();  
        public DbSet<Student> Students => Set <Student>();
    }
}
