using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;

namespace WCGAcademic.InMemoryData
{
    public class CourseRegisterService : ICourseRegisterService
    {
        private readonly MemoryDbContext _context;
        private readonly NavigationManager _navigationManager;

        public CourseRegisterService(MemoryDbContext context, NavigationManager navigationManager)
        {
            _context = context;
            _navigationManager = navigationManager;
            _context.Database.EnsureCreated();
            //_navigationManager.NavigateTo("/academia/course");
        }

        public List<CourseRegister> CourseRegisters { get; set; } = new List<CourseRegister>();
       // List<CourseRegister> ICourseRegisterService.CourseRegister { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public async Task CourseRegister()
        {
            CourseRegisters = await _context.CourseRegisters.ToListAsync();
        }


        public async Task GetCourseRegister()
        {
            CourseRegisters = await _context.CourseRegisters.ToListAsync();
        }

        public async Task CreateCourseRegister(CourseRegister courseRegister)
        {
            _context.CourseRegisters.Add(courseRegister);
            await _context.SaveChangesAsync();
            // _navigationManager.NavigateTo("/academia/course");
        }

        public async Task<List<CourseRegister>> GetCourseRegisterByCode(string code)
        {
           var regs = from p in _context.CourseRegisters
                             where p.CourseCode == code
                             select p;
            if (regs == null)
                throw new Exception("No lecturer here ..../");
            return regs.ToList();
        

        }
        public async Task<List<CourseRegister>> GetStudentRegisterByCode(int id)
        {
            var regs = from p in _context.CourseRegisters
                       where p.PersonId == id
                       select p;
           // if (regs != null)
            //    throw new Exception("You cannot registered a course more than once ..../");
            return regs.ToList();
        }

        public async Task<List<CourseRegister>> GetStudentRegisterByCodeByStatus(string code, string status)
        {
            var regs = from p in _context.CourseRegisters
                       where p.PersonCode == code && p.Status == status 
                       select p;
            if (regs.Count() != 0)
                throw new Exception("No lecturer here ..../");
            return regs.ToList();
        }

        public async Task<List<CourseRegister>> GetRegisterByCodeByStatus(string coursecode, string status)
        {
            var regs = from p in _context.CourseRegisters
                       where p.CourseCode == coursecode && p.Status == status
                       select p;
            if (regs.Count() != 0)
                throw new Exception("No lecturer here ..../");
            return regs.ToList()   ;
        }

        public async Task<List<CourseRegister>> GetRegisterByCodeByUserId(int id)
        {
            var regs = from p in _context.CourseRegisters
                       where p.PersonId == id
                       select p;
            //if (regs.Count() != 0)
               // throw new Exception("No registers here ..../");
            return regs.ToList();
        }

        public async Task<List<CourseRegister>> GetStudentRegisterByCode(int id, string code, string status)
        {
            var regs = from p in _context.CourseRegisters
                       where p.PersonId == id && p.CourseCode == code && p.Status == status
                       select p;
            if (regs.Count() != 0)
                throw new Exception("Already registered, multiple request not allowed ..../");
            else if (status == "De-registered")
                throw new Exception("Register first before de-registering");
                return regs.ToList();
        }


        public async Task DeleteCourseRegister(int id)
        {
            var dbCourseRegister = await _context.CourseRegisters.FindAsync(id);
            if (dbCourseRegister == null)
                throw new Exception("No lecturer here ..../");
            _context.CourseRegisters.Remove(dbCourseRegister);
            await _context.SaveChangesAsync();
            // _navigationManager.NavigateTo("/academia/course");

        }

        public async Task<CourseRegister> GetSingleCourseRegister(int id)
        {
            var courseRegister = await _context.CourseRegisters.FindAsync(id);
            //if (courseRegister == null)
            //{
            //    throw new Exception("No course register here ..../");
            //}
            return courseRegister!;
        }

        public async Task UpdateCourseRegister(CourseRegister courseRegister, int id)
        {
            var dbCourseRegister = await _context.CourseRegisters.FindAsync(id);
            if (dbCourseRegister != null)
            //throw new Exception("No lecturer here .../");
            {
                dbCourseRegister.PersonId = courseRegister.PersonId;
                dbCourseRegister.CourseCode = courseRegister.CourseCode;
                dbCourseRegister.Status = courseRegister.Status;
                dbCourseRegister.StudentName = courseRegister.StudentName;
            }
            else
            {
                await _context.CourseRegisters.AddAsync(courseRegister);
            }

                await _context.SaveChangesAsync();
        }

  
    }
}

