using Inventors.API.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Inventors.API.Services
{
    public interface IInventorService
    {
        Task<List<Inventor>> GetInventorsAsync();

        Task<Inventor> GetInventorByIdAsync(long id);

        Task<bool> CreateInventor(Inventor inventor);

        Task<bool> UpdateInventor(Inventor inventor);

        Task<bool> DeleteInventor(long id);
    }
}
