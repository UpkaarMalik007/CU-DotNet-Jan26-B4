using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentCourseManagement.DTOs;
using StudentCourseManagement.Services;

namespace StudentCourseManagement.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentController : ControllerBase
    {
        private readonly IEnrollmentService _service;

        public EnrollmentController(IEnrollmentService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Enroll(EnrollmentDto dto)
        {
            var result = await _service.Enroll(dto);

            if (!result) return NotFound();

            return Ok("Student enrolled successfully");
        }
    }
}
