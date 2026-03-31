using StudentCourseManagement.DTOs;

namespace StudentCourseManagement.Services
{
    public interface IEnrollmentService
    {
        Task<bool> Enroll(EnrollmentDto dto);
    }
}
