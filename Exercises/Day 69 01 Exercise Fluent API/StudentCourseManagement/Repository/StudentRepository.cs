using Microsoft.EntityFrameworkCore;
using StudentCourseManagement.Data;
using StudentCourseManagement.Models;

namespace StudentCourseManagement.Repository
{
    public class StudentRepository:IStudentRepository
    {
        private readonly StudentCourseManagementContext _context;
        public StudentRepository(StudentCourseManagementContext context) => _context = context;

        public async Task<List<Student>> GetAll() =>
            await _context.Students.Include(s => s.Courses).ToListAsync();

        public async Task<Student> GetById(int id) =>
            await _context.Students.Include(s => s.Courses)
                .FirstOrDefaultAsync(x => x.Id == id);

        public async Task Add(Student student)
        {
            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Student student)
        {
            _context.Students.Update(student);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Student student)
        {
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
        }
    }
}
