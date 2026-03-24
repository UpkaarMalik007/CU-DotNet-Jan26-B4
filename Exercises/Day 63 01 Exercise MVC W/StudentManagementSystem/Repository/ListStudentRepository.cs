using StudentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.Repository
{

    
    internal class ListStudentRepository: IStudentRepository
    {
        private readonly List<Student> _students = new List<Student>();

        public void AddStudents(Student student)
        {
            _students.Add(student);
        }

        public IEnumerable<Student> GetStudents()
        {
            return _students;
        }

        public void RemoveStudents(int id)
        {
            var student = _students.FirstOrDefault(s => s.StudentId == id);
            if (student != null)
                _students.Remove(student);
        }

        
        public void UpdateStudents(Student student)
        {
            var existing = _students.FirstOrDefault(s => s.StudentId ==student.StudentId);
            if (existing != null)
            {
                existing.Name = student.Name;
                existing.Grade = student.Grade;
            }
        }
    }
}
