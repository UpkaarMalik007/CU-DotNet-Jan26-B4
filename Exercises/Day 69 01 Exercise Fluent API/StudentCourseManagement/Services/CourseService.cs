using StudentCourseManagement.Models;
using StudentCourseManagement.Repository;
using static StudentCourseManagement.DTOs.CourseDto;

namespace StudentCourseManagement.Services
{
    public class CourseService:ICourseService
    {
        private readonly ICourseRepository _repo;
        public CourseService(ICourseRepository repo) => _repo = repo;

        public async Task<List<CourseResponseDto>> GetAll()
        {
            var courses = await _repo.GetAll();

            return courses.Select(x => new CourseResponseDto
            {
                Id = x.Id,
                Title = x.Title,
                Credits = x.Credits
            }).ToList();
        }

        public async Task<CourseResponseDto> GetById(int id)
        {
            var course = await _repo.GetById(id);
            if (course == null) return null;

            return new CourseResponseDto
            {
                Id = course.Id,
                Title = course.Title,
                Credits = course.Credits
            };
        }

        public async Task<CourseResponseDto> Create(CreateCourseDto dto)
        {
            var course = new Course
            {
                Title = dto.Title,
                Credits = dto.Credits
            };

            await _repo.Add(course);

            return new CourseResponseDto
            {
                Id = course.Id,
                Title = course.Title,
                Credits = course.Credits
            };
        }

        public async Task<bool> Update(int id, UpdateCourseDto dto)
        {
            var course = await _repo.GetById(id);
            if (course == null) return false;

            course.Title = dto.Title;
            course.Credits = dto.Credits;

            await _repo.Update(course);
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var course = await _repo.GetById(id);
            if (course == null) return false;

            await _repo.Delete(course);
            return true;
        }
    }
}
