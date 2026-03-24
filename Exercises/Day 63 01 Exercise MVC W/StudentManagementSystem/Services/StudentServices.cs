using StudentManagementSystem.Models;
using StudentManagementSystem.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.Services
{
    internal class StudentServices : IStudentServices
    {

        private readonly IStudentRepository _repository;

        public StudentServices(IStudentRepository repository)
        {
            _repository = repository;
        }

        public void AddStudents(Student student)
        {
            if (student.Grade < 0 || student.Grade > 100)
                throw new Exception("Grade must be between 0 and 100.");

            _repository.AddStudents(student);
        }

        public IEnumerable<Student> GetStudents()
        {
            return _repository.GetStudents();
        }

        

        public void UpdateStudents(Student student)
        {
            if (student.Grade < 0 || student.Grade > 100)
                throw new Exception("Invalid grade.");

            _repository.UpdateStudents(student);
        }

        public void RemoveStudents(int id)
        {
            _repository.RemoveStudents(id);
        }

        
    }
}
