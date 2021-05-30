using Inventors.API.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Inventors.API.Services
{
    public interface IInventorService
    {
        Task<List<Inventor>> GetInventorsAsync();

        Task<Inventor> GetInventorByIdAsync(long id);

        Task<bool> Create(Inventor inventor);
    }
}
