using static StudentCourseManagement.DTOs.CourseDto;

namespace StudentCourseManagement.Services
{
    public interface ICourseService
    {
        Task<List<CourseResponseDto>> GetAll();
        Task<CourseResponseDto> GetById(int id);
        Task<CourseResponseDto> Create(CreateCourseDto dto);
        Task<bool> Update(int id, UpdateCourseDto dto);
        Task<bool> Delete(int id);
    }
}
