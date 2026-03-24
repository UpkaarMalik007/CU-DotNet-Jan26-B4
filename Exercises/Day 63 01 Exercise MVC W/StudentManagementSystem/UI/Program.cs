using StudentManagementSystem.Services;
using StudentManagementSystem.Repository;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.UI

{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Select Storage Type:");
            Console.WriteLine("1. In-Memory");
            Console.WriteLine("2. JSON File");

            Console.Write("Choice: ");
            var choice = Console.ReadLine();

            IStudentRepository repository;

           
            if (choice == "1")
                repository = new ListStudentRepository();
            else
                repository = new JsonStudentRepository();

            var service = new StudentServices(repository);

            while (true)
            {
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. View All");
                Console.WriteLine("3. Update Student");
                Console.WriteLine("4. Delete Student");
                Console.WriteLine("5. Exit");

                Console.Write("Select option: ");
                var option = Console.ReadLine();

                try
                {
                    switch (option)
                    {
                        case "1":
                            Console.Write("Id: ");
                            int id = int.Parse(Console.ReadLine());

                            Console.Write("Name: ");
                            string name = Console.ReadLine();

                            Console.Write("Grade: ");
                            int grade = int.Parse(Console.ReadLine());

                            service.AddStudents(new Student
                            {
                                StudentId = id,
                                Name = name,
                                Grade = grade
                            });
                            break;

                        case "2":
                            var students = service.GetStudents();
                            foreach (var s in students)
                            {
                                Console.WriteLine($"{s.StudentId} - {s.Name} - {s.Grade}");
                            }
                            break;

                        case "3":
                            Console.Write("Id: ");
                            id = int.Parse(Console.ReadLine());

                            Console.Write("New Name: ");
                            name = Console.ReadLine();

                            Console.Write("New Grade: ");
                            grade = int.Parse(Console.ReadLine());

                            service.UpdateStudents(new Student
                            {
                                StudentId = id,
                                Name = name,
                                Grade = grade
                            });
                            break;

                        case "4":
                            Console.Write("Id: ");
                            id = int.Parse(Console.ReadLine());
                            service.RemoveStudents(id);
                            break;

                        case "5":
                            return;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }

        }

        
    }
}
