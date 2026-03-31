using static StudentCourseManagement.DTOs.StudentDto;

namespace StudentCourseManagement.Services
{
    public interface IStudentService
    {
        Task<List<StudentResponseDto>> GetAll();
        Task<StudentResponseDto> GetById(int id);
        Task<StudentResponseDto> Create(CreateStudentDto dto);
        Task<bool> Update(int id, UpdateStudentDto dto);
        Task<bool> Delete(int id);
    }
}
