using FrontendMVC.ViewModel;

namespace FrontendMVC.Services
{
    public interface IDestinationService
    {
        Task<List<DestinationViewModel>> GetAllAsync();
        Task<DestinationViewModel> GetByIdAsync(int id);
        Task CreateAsync(AddDestinationViewModel model);
        Task UpdateAsync(int id, UpdateDestinationViewModel model);
        Task DeleteAsync(int id);
    }
}
