using StudentCourseManagement.Models;

namespace StudentCourseManagement.Repository
{
    public interface ICourseRepository
    {
        Task<List<Course>> GetAll();
        Task<Course> GetById(int id);
        Task Add(Course course);
        Task Update(Course course);
        Task Delete(Course course);
    }
}
