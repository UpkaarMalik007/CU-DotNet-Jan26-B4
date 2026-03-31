using Microsoft.EntityFrameworkCore;
using StudentCourseManagement.Data;
using StudentCourseManagement.Models;

namespace StudentCourseManagement.Repository
{
    public class CourseRepository:ICourseRepository
    {
        private readonly StudentCourseManagementContext _context;
        public CourseRepository(StudentCourseManagementContext context) => _context = context;

        public async Task<List<Course>> GetAll() =>
            await _context.Courses.ToListAsync();

        public async Task<Course> GetById(int id) =>
            await _context.Courses.FindAsync(id);

        public async Task Add(Course course)
        {
            await _context.Courses.AddAsync(course);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Course course)
        {
            _context.Courses.Update(course);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Course course)
        {
            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();
        }
    }
}
