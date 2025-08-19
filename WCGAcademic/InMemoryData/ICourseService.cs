namespace WCGAcademic.InMemoryData
{
    public interface ICourseService
    {
        List<Course> Courses { get; set; }
        Task GetCourses();
        Task <Course> GetSingleCourse(int id);
        Task CreateCourse (Course course);
        Task UpdateCourse (Course course,int id);
        Task DeleteCourse (int id);
        Task<Course> GetCourseByCode(string code);

    }
}
