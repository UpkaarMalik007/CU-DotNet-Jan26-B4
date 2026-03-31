using StudentCourseManagement.Models;
using StudentCourseManagement.Repository;
using static StudentCourseManagement.DTOs.StudentDto;

namespace StudentCourseManagement.Services
{
    public class StudentService:IStudentService
    {
        private readonly IStudentRepository _repo;
        public StudentService(IStudentRepository repo) => _repo = repo;

        public async Task<List<StudentResponseDto>> GetAll()
        {
            var students = await _repo.GetAll();

            return students.Select(x => new StudentResponseDto
            {
                Id = x.Id,
                Name = x.Name,
                Email = x.Email,
                Age = x.Age
            }).ToList();
        }

        public async Task<StudentResponseDto> GetById(int id)
        {
            var student = await _repo.GetById(id);
            if (student == null) return null;

            return new StudentResponseDto
            {
                Id = student.Id,
                Name = student.Name,
                Email = student.Email,
                Age = student.Age
            };
        }

        public async Task<StudentResponseDto> Create(CreateStudentDto dto)
        {
            var student = new Student
            {
                Name = dto.Name,
                Email = dto.Email,
                Age = dto.Age
            };

            if (student.Email != null)
                throw new Exception("Email already exists");

            await _repo.Add(student);

            return new StudentResponseDto
            {
                Id = student.Id,
                Name = student.Name,
                Email = student.Email,
                Age = student.Age
            };
        }

        public async Task<bool> Update(int id, UpdateStudentDto dto)
        {
            var student = await _repo.GetById(id);
            if (student == null) return false;

            student.Name = dto.Name;
            student.Email = dto.Email;
            student.Age = dto.Age;

            await _repo.Update(student);
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var student = await _repo.GetById(id);
            if (student == null) return false;

            await _repo.Delete(student);
            return true;
        }
    }
}
