using BackendAPI.Model;

namespace BackendAPI.Repository
{
    public interface IDestinationRepository
    {
        Task<List<Destination>> GetAllAsync();
        Task<Destination> GetByIdAsync(int id);
        Task AddAsync(Destination destination);
        Task UpdateAsync(Destination destination);
        Task<bool> DeleteAsync(int id);
    }
}
