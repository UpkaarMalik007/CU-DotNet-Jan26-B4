using StudentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.Services
{
    internal interface IStudentServices
    {
        void AddStudents(Student student);
        public IEnumerable<Student> GetStudents();
        void RemoveStudents(int id);
        void UpdateStudents(Student student);
    }
}
