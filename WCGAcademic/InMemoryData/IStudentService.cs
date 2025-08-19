namespace WCGAcademic.InMemoryData
{
    public interface IStudentService
    {

        List<Student> Students { get; set; }
        Task GetStudent();
        Task<Student> GetSingleStudent(int id);
        Task CreateStudent(Student student);
        Task UpdateStudent(Student student, int id);
        Task DeleteStudent(int id);
    }
}
