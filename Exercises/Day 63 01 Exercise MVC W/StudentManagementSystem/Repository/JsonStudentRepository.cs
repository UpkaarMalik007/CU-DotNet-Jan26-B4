using StudentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace StudentManagementSystem.Repository
{
    internal class JsonStudentRepository : IStudentRepository
    {
        private string path = @"students.json";
        private List<Student> LoadData()
        {
            if (!File.Exists(path))
            {
                return new List<Student>();
            }
            var json = File.ReadAllText(path);
            return JsonSerializer.Deserialize<List<Student>>(json);

        }

        private void SaveData(List<Student> students)
        {
            var json = JsonSerializer.Serialize(students, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(path, json);
        }
        public void AddStudents(Student student)
        {
            var students = LoadData();
            students.Add(student);
            SaveData(students);
        }

        public IEnumerable<Student> GetStudents()
        {
            return LoadData();
        }

        public void RemoveStudents(int id)
        {
            var students = LoadData();
            var student = students.FirstOrDefault(s => s.StudentId == id);
            if (student != null)
            {
                students.Remove(student);
                SaveData(students);
            }
        }

        public void UpdateStudents(Student student)
        {
            var students = LoadData();
            var existing = students.FirstOrDefault(s => s.StudentId == student.StudentId);
            if (existing != null)
            {
                existing.Name = student.Name;
                existing.Grade = student.Grade;
                SaveData(students);
            }
        }
    }
}
