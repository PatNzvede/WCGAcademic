using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;

namespace WCGAcademic.InMemoryData
{
    public class StudentService : IStudentService
    {
        private readonly MemoryDbContext _context;
        private readonly NavigationManager _navigationManager;

        public StudentService(MemoryDbContext context, NavigationManager navigationManager)
        {
            _context = context;
            _navigationManager = navigationManager;
            _context.Database.EnsureCreated();
            //_navigationManager.NavigateTo("/academia/course");
        }

        public List<Student> Students { get; set; } = new List<Student>();
        public async Task GetStudents()
        {
            Students = await _context.Students.ToListAsync();
        }

        public async Task CreateStudent(Student student)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
            // _navigationManager.NavigateTo("/academia/course");
        }

        public async Task DeleteStudent(int id)
        {
            var dbStudent = await _context.Students.FindAsync(id);
            if (dbStudent == null)
                throw new Exception("No student here ..../");
            _context.Students.Remove(dbStudent);
            await _context.SaveChangesAsync();
            // _navigationManager.NavigateTo("/academia/course");

        }

        public async Task<Student> GetSingleStudent(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                throw new Exception("No student here ..../");
            }
            return student;
        }

        public async Task UpdateStudent(Student student, int id)
        {
            var dbStudent = await _context.Students.FindAsync(id);
            if (dbStudent == null)
                throw new Exception("No student here .../");

            dbStudent.CourseCode = student.CourseCode;
            dbStudent.PersonId = student.PersonId;
           dbStudent.Status = student.Status;   

            await _context.SaveChangesAsync();
        }

        Task IStudentService.GetStudent()
        {
            throw new NotImplementedException();
        }
    }
}
