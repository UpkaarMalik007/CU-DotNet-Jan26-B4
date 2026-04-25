using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using TicketBookingSystem.TripService.Common;
using TicketBookingSystem.TripService.DTOs;
using TicketBookingSystem.TripService.Models;
using TicketBookingSystem.TripService.Services;

namespace TicketBookingSystem.TripService.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class TripsController : ControllerBase
    {
        private readonly ITripService _service;
        private readonly IMapper _mapper;

        public TripsController(ITripService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Trip>>> GetTrips()
        {
            return Ok(await _service.GetAllTripsAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TripWithItineraryDto>> GetTrip(int id)
        {
            return Ok(await _service.GetTripByIdAsync(id));
        }

        [HttpPost]
        public async Task<ActionResult<Trip>> PostTrip(CreateTripDto dto)
        {
            var createdTrip = await _service.CreateTripAsync(dto);

            // Map the entity to the output DTO
            var mappedTripDto = _mapper.Map<TripWithItineraryDto>(createdTrip);

            var response = new ApiResponse<TripWithItineraryDto>
            {
                Success = true,
                Message = "Trip Created", // Fixed the typo
                Data = mappedTripDto      // 3. Assigned the mapped data here
            };
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrip(int id, Trip trip)
        {
            await _service.UpdateTripAsync(id, trip);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrip(int id)
        {
            await _service.DeleteTripAsync(id);
            return NoContent();
        }
    }
}