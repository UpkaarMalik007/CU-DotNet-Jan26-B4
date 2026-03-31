using Microsoft.EntityFrameworkCore;
using StudentCourseManagement.Data;
using StudentCourseManagement.DTOs;

namespace StudentCourseManagement.Services
{
    public class EnrollmentService:IEnrollmentService
    {
        private readonly StudentCourseManagementContext _context;

        public EnrollmentService(StudentCourseManagementContext context)
        {
            _context = context;
        }

        public async Task<bool> Enroll(EnrollmentDto dto)
        {
            var student = await _context.Students
                .Include(s => s.Courses)
                .FirstOrDefaultAsync(s => s.Id == dto.StudentId);

            var course = await _context.Courses.FindAsync(dto.CourseId);

            if (student == null || course == null)
                return false;

            student.Courses.Add(course);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
