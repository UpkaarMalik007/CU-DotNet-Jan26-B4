using BackendAPI.DTOs;
using BackendAPI.Execeptions;
using BackendAPI.Model;
using BackendAPI.Repository;
using BackendAPI.Services;



namespace TravelDestinationAPI.Services
{
    public class DestinationService : IDestinationService
    {
        private readonly IDestinationRepository _repository;

        public DestinationService(IDestinationRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Destination>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Destination> GetByIdAsync(int id)
        {
            var destination = await _repository.GetByIdAsync(id);

            if (destination == null)
                throw new DestinationNotFoundException(id);

            return destination;
        }

        public async Task<Destination> AddAsync(AddDestinationDto dto)
        {
            var destination = new Destination
            {
                CityName = dto.CityName,
                Country = dto.Country,
                Description = dto.Description,
                Rating = dto.Rating
            };

            await _repository.AddAsync(destination);
            return destination;
        }

        public async Task<bool> UpdateAsync(int id, UpdateDestinationDto dto)
        {
            var existing = await _repository.GetByIdAsync(id);

            if (existing == null)
                throw new DestinationNotFoundException(id);

            existing.CityName = dto.CityName;
            existing.Country = dto.Country;
            existing.Description = dto.Description;
            existing.Rating = dto.Rating;

            await _repository.UpdateAsync(existing);
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await _repository.GetByIdAsync(id);

            if (existing == null)
                throw new DestinationNotFoundException(id);

            return await _repository.DeleteAsync(id);
        }
    }
}