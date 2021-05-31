using Inventors.API.Data;
using Inventors.API.Data.Models;
using Inventors.API.Domain.EntityValidators;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Inventors.API.Services
{
    public class InventorService : IInventorService
    {
        private readonly ApplicationDbContext _context;

        public InventorService(ApplicationDbContext context)
        {
            _context = context;
        }



        public async Task<Inventor> GetInventorByIdAsync(long id)
        {
            return await _context.Inventors.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Inventor>> GetInventorsAsync()
        {
            return await _context.Inventors.ToListAsync();
        }

        public async Task<InventorValidationResponse> CreateInventor(Inventor inventor)
        {
            var result = new InventorValidationResponse();

            if (!InventorValidator.ValidateInventor(inventor, _context, out var messages))
            {
                result.Messages.AddRange(messages);
                return result;
            }

            await _context.Inventors.AddAsync(inventor);
            var saveResult = await _context.SaveChangesAsync();

            if (saveResult > 0)
            {
                result.Success = true;
                return result;
            }

            result.Messages.Add("Something went wrong, please try again");
            return result;
        }

        public async Task<InventorValidationResponse> UpdateInventor(Inventor inventor)
        {
            var result = new InventorValidationResponse();

            if (!InventorValidator.ValidateInventor(inventor, _context, out var messages))
            {
                result.Messages.AddRange(messages);
                return result;
            }
            _context.Inventors.Update(inventor);
            var saveResult = await _context.SaveChangesAsync();
            if (saveResult > 0)
            {
                result.Success = true;
                return result;
            }

            result.Messages.Add("Something went wrong, please try again");
            return result;
        }

        public async Task<bool> DeleteInventor(long id)
        {
            var inventorToDelete = await GetInventorByIdAsync(id);

            if (inventorToDelete == null)
            {
                return false;
            }
            _context.Inventors.Remove(inventorToDelete);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }
    }
}
