using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace WCGAcademic.InMemoryData
{
    public class CourseService : ICourseService
    {
        private readonly MemoryDbContext _context;
        private readonly NavigationManager _navigationManager;

        public CourseService(MemoryDbContext context , NavigationManager navigationManager ) 
        {
            _context = context;
            _navigationManager = navigationManager;
            _context.Database.EnsureCreated();
            //_navigationManager.NavigateTo("/academia/course");
        }

        public List<Course> Courses { get; set; } = new List<Course>();

       
        public async Task GetCourses ()
        {
            Courses = await _context.Courses.ToListAsync();
        }

        public async Task CreateCourse(Course course)
        {
          _context.Courses.Add(course);
            await _context.SaveChangesAsync();
           // _navigationManager.NavigateTo("/academia/course");
        }

        public  async Task DeleteCourse(int id)
        {
            var dbCourse = await _context.Courses.FindAsync(id);
            if (dbCourse == null)
               throw new Exception("No course here ..../");
            _context.Courses.Remove(dbCourse);
            await _context.SaveChangesAsync();
           // _navigationManager.NavigateTo("/academia/course");

        }
       

        public async Task<Course> GetCourseByCode(string code)
        {
            var course = await _context.Courses.SingleOrDefaultAsync(a => a.CourseCode == code);
            if (course == null)
            {
                throw new Exception("No person here ..../");
            }
            return course;
        }
        public async Task<Course> GetSingleCourse(int id)
        {
           var course = await _context.Courses.FindAsync(id);
            if(course == null)
            {
                throw new Exception("No course here ..../");
            }
            return course;
        }

        public  async Task UpdateCourse(Course course, int id)
        {
            var dbCourse = await _context.Courses.FindAsync(id);
            if (dbCourse == null)
                throw new Exception("No game here .../");

            dbCourse.CourseCode = course.CourseCode;
            dbCourse.Name = course.Name;

            await _context.SaveChangesAsync();
        }
    }
}
