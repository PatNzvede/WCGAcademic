using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;

namespace WCGAcademic.InMemoryData
{
    public class LecturerService : ILecturerService

    {
        private readonly MemoryDbContext _context;
        private readonly NavigationManager _navigationManager;

        public LecturerService(MemoryDbContext context, NavigationManager navigationManager)
        {
            _context = context;
            _navigationManager = navigationManager;
            _context.Database.EnsureCreated();
            //_navigationManager.NavigateTo("/academia/course");
        }

        public List<Lecturer> Lecturers { get; set; } = new List<Lecturer>();
    

        public async Task GetLecturers()
        {
            Lecturers = await _context.Lecturers.ToListAsync();
        }

        public async Task CreateLecturer(Lecturer lecturer)
        {
            _context.Lecturers.Add(lecturer);
            await _context.SaveChangesAsync();
            // _navigationManager.NavigateTo("/academia/course");
        }

        public async Task DeleteLecturer(int id)
        {
            var dbLecturer = await _context.Lecturers.FindAsync(id);
            if (dbLecturer == null)
                throw new Exception("No lecturer here ..../");
            _context.Lecturers.Remove(dbLecturer);
            await _context.SaveChangesAsync();
            // _navigationManager.NavigateTo("/academia/course");

        }

        public async Task<Lecturer> GetSingleLecturer(int id)
        {
            var lecturer = await _context.Lecturers.FindAsync(id);
            if (lecturer == null)
            {
                throw new Exception("No lecturer here ..../");
            }
            return lecturer;
        }

        public async Task UpdateLecturer(Lecturer lecturer, int id)
        {
            var dbLecturer = await _context.Lecturers.FindAsync(id);
            if (dbLecturer == null)
                throw new Exception("No lecturer here .../");

            dbLecturer.PersonId = lecturer.PersonId;
            dbLecturer.CourseCode = lecturer.CourseCode;

            await _context.SaveChangesAsync();
        }
    }
}

    