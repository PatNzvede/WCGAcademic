namespace WCGAcademic.InMemoryData
{
    public interface ILecturerService
    {
        List<Lecturer> Lecturers { get; set; }
        Task GetLecturers();
        Task<Lecturer> GetSingleLecturer(int id);
        Task CreateLecturer(Lecturer lecturer);
        Task UpdateLecturer(Lecturer lecturer, int id);
        Task DeleteLecturer(int id);
    }
}
