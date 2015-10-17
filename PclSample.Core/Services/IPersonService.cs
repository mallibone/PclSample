using System.Collections.Generic;
using System.Threading.Tasks;
using PclSample.Core.Models;

namespace PclSample.Core.Services
{
    public interface IPersonService
    {
        Task<IEnumerable<Person>> GetPeople(int count = 42);
    }
}