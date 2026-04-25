using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrackingService.Data;
using TrackingService.DTOs;
using TrackingService.Models;
using TrackingService.Services;

namespace TrackingService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrackingController : ControllerBase
    {
        private readonly ITrackingServices _service;

        public TrackingController(ITrackingServices service)
        {
            _service = service;
        }

        //  ONLY DRIVER can add location
        [HttpPost]
        [Authorize]
        public IActionResult Add(CreateGpsDto dto)
        {
            _service.Add(dto);
            return Ok("Location Added");
        }

        //  ONLY MANAGER can view tracking data
        [HttpGet]
        [Authorize(Roles = "Manager")]
        public IActionResult GetAll()
        {
            return Ok(_service.GetAll());
        }
    }
}
