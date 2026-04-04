using BackendAPI.Model;
using BackendAPI.DTOs;

namespace BackendAPI.Services
{
    public interface IDestinationService
    {
        Task<List<Destination>> GetAllAsync();
        Task<Destination> GetByIdAsync(int id);
        Task<Destination> AddAsync(AddDestinationDto dto);
        Task<bool> UpdateAsync(int id, UpdateDestinationDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
