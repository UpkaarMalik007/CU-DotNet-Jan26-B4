using Microsoft.EntityFrameworkCore;
using NorthwindCatalog.Services.Data;
using NorthwindCatalog.Services.DTOs;
using NorthwindCatalog.Services.Models;

namespace NorthwindCatalog.Services.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly NorthwindContext _context;

        public ProductRepository(NorthwindContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetByCategoryIdAsync(int categoryId)
        {
            return await _context.Products
                .Where(p => p.CategoryId == categoryId)
                .ToListAsync();
        }

        public async Task<IEnumerable<CategorySummaryDto>> GetCategorySummariesAsync()
        {
            var categories = await _context.Categories
        .Include(c => c.Products)
        .ToListAsync();   // ✅ bring data into memory

            return categories.Select(c => new CategorySummaryDto
            {
                CategoryName = c.CategoryName,

                ProductCount = c.Products.Count(),

                AvgPrice = c.Products
                    .Where(p => p.UnitPrice.HasValue)
                    .Select(p => p.UnitPrice.Value)
                    .DefaultIfEmpty(0)
                    .Average(),

                MostExpensiveProduct = c.Products
                    .Where(p => p.UnitPrice.HasValue)
                    .OrderByDescending(p => p.UnitPrice)
                    .Select(p => p.ProductName)
                    .FirstOrDefault()
            });
        }
    }
}

