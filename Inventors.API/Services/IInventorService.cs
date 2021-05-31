using Inventors.API.Data.Models;
using Inventors.API.Domain.EntityValidators;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Inventors.API.Services
{
    public interface IInventorService
    {
        Task<List<Inventor>> GetInventorsAsync();

        Task<Inventor> GetInventorByIdAsync(long id);

        Task<InventorValidationResponse> CreateInventor(Inventor inventor);

        Task<InventorValidationResponse> UpdateInventor(Inventor inventor);

        Task<bool> DeleteInventor(long id);
    }
}
