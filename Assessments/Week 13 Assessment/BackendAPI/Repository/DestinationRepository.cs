using BackendAPI.Data;
using BackendAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace BackendAPI.Repository
{
    public class DestinationRepository:IDestinationRepository
    {
        private readonly BackendAPIContext _context;
        public DestinationRepository(BackendAPIContext context)
        {
            _context = context;
        }

        public async Task<List<Destination>> GetAllAsync()
        {
            return await _context.Destination.ToListAsync();
        }

        public async Task<Destination> GetByIdAsync(int id)
        {
            return await _context.Destination.FindAsync(id);
        }

        public async Task AddAsync(Destination destination)
        {
            await _context.Destination.AddAsync(destination);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Destination destination)
        {
            _context.Destination.Update(destination);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var destination = await _context.Destination.FindAsync(id);

            if (destination == null)
                return false;

            _context.Destination.Remove(destination);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
