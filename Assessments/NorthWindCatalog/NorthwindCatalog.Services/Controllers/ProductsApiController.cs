using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NorthwindCatalog.Services.DTOs;
using NorthwindCatalog.Services.Repository;

namespace NorthwindCatalog.Services.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsApiController : ControllerBase
    {
        private readonly IProductRepository _repo;
        private readonly IMapper _mapper;

        public ProductsApiController(IProductRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet("by-category/{id}")]
        public async Task<IActionResult> GetByCategory(int id)
        {
            var data = await _repo.GetByCategoryIdAsync(id);
            return Ok(_mapper.Map<IEnumerable<ProductDto>>(data));
        }

        [HttpGet("summary")]
        public async Task<IActionResult> GetSummary()
        {
            var data = await _repo.GetCategorySummariesAsync();
            return Ok(data);
        }
    }
}
