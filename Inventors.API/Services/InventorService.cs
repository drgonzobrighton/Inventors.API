using Inventors.API.Data;
using Inventors.API.Domain;
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

        public async Task<bool> CreateInventor(Inventor inventor)
        {
            await _context.Inventors.AddAsync(inventor);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<Inventor> GetInventorByIdAsync(long id)
        {
            return await _context.Inventors.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Inventor>> GetInventorsAsync()
        {
            return await _context.Inventors.ToListAsync();
        }

        public async Task<bool> UpdateInventor(Inventor inventor)
        {
            _context.Inventors.Update(inventor);
            var result = await _context.SaveChangesAsync();
            return result > 0;
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
