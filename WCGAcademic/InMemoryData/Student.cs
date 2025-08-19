namespace WCGAcademic.InMemoryData
{
    public class Student
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public string CourseCode { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
    }
}
