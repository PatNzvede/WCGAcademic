using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;

namespace WCGAcademic.InMemoryData
{
    public class PersonService : IPersonService
    {
        private readonly MemoryDbContext _context;
        private readonly NavigationManager _navigationManager;

        public PersonService(MemoryDbContext context, NavigationManager navigationManager)
        {
            _context = context;
            _navigationManager = navigationManager;
            _context.Database.EnsureCreated();
            //_navigationManager.NavigateTo("/academia/course");
        }

        public List<Person> People { get; set; } = new List<Person>();
        public async Task GetPeople()
        {
            People = await _context.People.ToListAsync();
        }

        public async Task CreatePerson(Person person)
        {
            _context.People.Add(person);
            await _context.SaveChangesAsync();
            // _navigationManager.NavigateTo("/academia/course");
        }

        public async Task DeletePerson(int id)
        {
            var dbPerson = await _context.People.FindAsync(id);
            if (dbPerson == null)
                throw new Exception("No person here ..../");
            _context.People.Remove(dbPerson);
            await _context.SaveChangesAsync();
            // _navigationManager.NavigateTo("/academia/course");

        }

        public async Task<Person> GetSinglePerson(int id)
        {
            var person = await _context.People.FindAsync(id);
            //if (person == null)
            //{
            //    throw new Exception("No person here ..../");
            //}
            return person;
        }
        public async Task<Person> GetGuidPerson(string id)
        {
            var person = await _context.People.SingleOrDefaultAsync(a=>a.IdentityId == id);
            //if (person == null)
            //{
            //    throw new Exception("No person here ..../");
            //}
            return person;
        }


        public async Task UpdatePerson(Person person, int id)
        {
            var dbPerson= await _context.People.FindAsync(id);
            if (dbPerson == null)
                throw new Exception("No game here .../");

            dbPerson.Email = person.Email;
            dbPerson.Role = person.Role;
            

            await _context.SaveChangesAsync();
        }
    }
}
