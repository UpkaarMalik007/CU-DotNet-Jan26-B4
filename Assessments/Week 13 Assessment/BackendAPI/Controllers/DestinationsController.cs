using BackendAPI.Data;
using BackendAPI.DTOs;
using BackendAPI.Model;
using BackendAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DestinationsController : ControllerBase
    {
        private readonly BackendAPIContext _context;
        private readonly IDestinationService _service;
        public DestinationsController(BackendAPIContext context,IDestinationService service)
        {
            _context = context;
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{id}", Name = "GetDestinationById")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            return Ok(await _service.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(AddDestinationDto dto)
        {
            var result = await _service.AddAsync(dto);
            return CreatedAtRoute(
         "GetDestinationById",
         new { id = result.Id },
         result
     );
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, UpdateDestinationDto dto)
        {
            await _service.UpdateAsync(id, dto);
            return Ok(new { message = "Destination updated successfully" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _service.DeleteAsync(id);
            return Ok(new { message = "Destination deleted successfully" });
        }
    }
}
