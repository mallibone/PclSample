using System.Collections.Generic;
using System.Threading.Tasks;
using PclSample.Core.Models;

namespace PclSample.Core.Services.Impl
{
    public class PersonService : IPersonService
    {
        public async Task<IEnumerable<Person>> GetPeople(int count = 42)
        {
            var people = new List<Person>(count);
            // In case of large counts lets be safe and not run this on the UI thread
            await Task.Run(() =>
            {
                for (int i = 0; i < count; ++i)
                {
                    people.Add(new Person{FirstName = NameGenerator.GenRandomFirstName(), LastName = NameGenerator.GenRandomLastName()});
                }
            });

            return people;
        }
    }
}
