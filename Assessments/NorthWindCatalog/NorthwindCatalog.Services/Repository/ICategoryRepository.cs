using NorthwindCatalog.Services.Models;

namespace NorthwindCatalog.Services.Repository
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllAsync();
    }
}
