namespace WCGAcademic.InMemoryData
{
    public interface IPersonService
    {
        List<Person> People { get; set; }
        Task GetPeople();
        Task<Person> GetSinglePerson(int id);
        Task CreatePerson(Person person);
        Task UpdatePerson(Person person, int id);
        Task DeletePerson(int id);
        Task<Person> GetGuidPerson(string id);
    }
}
