namespace WCGAcademic.InMemoryData
{
    public class CourseRegister
    {
        public int Id { get; set; }
        public string PersonCode { get; set; } = string.Empty;
        public int PersonId { get; set; }
        public string StudentName { get; set; } = string.Empty;
        public string CourseCode { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string UserId { get; set; }

        
    }
}
