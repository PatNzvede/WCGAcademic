namespace WCGAcademic.InMemoryData
{
    public interface ICourseRegisterService
    {
        List<CourseRegister> CourseRegisters { get; set; }
        Task GetCourseRegister();
        Task<CourseRegister> GetSingleCourseRegister(int id);
        Task CreateCourseRegister(CourseRegister courseRegister);
        Task UpdateCourseRegister(CourseRegister courseRegister, int id);
        Task DeleteCourseRegister(int id);
        Task<List<CourseRegister>> GetCourseRegisterByCode(string code);
        Task<List<CourseRegister>> GetStudentRegisterByCode(int id);
        Task<List<CourseRegister>> GetStudentRegisterByCodeByStatus(string id, string status);

        Task<List<CourseRegister>> GetStudentRegisterByCode(int id, string code, string status);
        Task<List<CourseRegister>> GetRegisterByCodeByStatus(string coursecode, string status);
        Task<List<CourseRegister>> GetRegisterByCodeByUserId(int id);







    }
}
