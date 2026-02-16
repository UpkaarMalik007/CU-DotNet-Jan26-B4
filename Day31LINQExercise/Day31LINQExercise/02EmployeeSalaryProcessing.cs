using Day31LINQExercise;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day31LINQExercise
{
    class Employee
    {
        public int Id;
        public string Name;
        public string Dept;
        public double Salary;
        public DateTime JoinDate;
    }


    internal class EmployeeSalaryProcessing
    {
        static void Main(string[] args)
        {
            var employees = new List<Employee>
            {
                new Employee{Id=1, Name="Ravi", Dept="IT", Salary=80000, JoinDate=new DateTime(2019,1,10)},
                new Employee{Id=2, Name="Anita", Dept="HR", Salary=60000, JoinDate=new DateTime(2021,3,5)},
                new Employee{Id=3, Name="Suresh", Dept="IT", Salary=120000, JoinDate=new DateTime(2018,7,15)},
                new Employee{Id=4, Name="Meena", Dept="Finance", Salary=90000, JoinDate=new DateTime(2022,9,1)}
            };

            var highestSalary = employees.GroupBy(x => x.Dept)
                                        .Select(y => new { Dept = y.Key, highestSalary = y.Max(s => s.Salary), lowestSaalry = y.Min(z => z.Salary) }).ToList();

            Console.WriteLine("---------------");
            Console.WriteLine("---------------");
            Console.WriteLine("Highest Salary in Each Dept");
            foreach (var i in highestSalary)
            {
                Console.WriteLine(i.Dept + " - " + i.highestSalary);

            }
            Console.WriteLine("---------------");
            Console.WriteLine("Lowest Salary in Each Dept");
            foreach (var i in highestSalary)
            {
                Console.WriteLine(i.Dept + " - " + i.lowestSaalry);

            }
            Console.WriteLine("---------------");

            var deptCount = employees.GroupBy(y => y.Dept).Select(x => new { Dept = x.Key, Count = x.Count() }).ToList();
            Console.WriteLine("Employee in each Dept");
            foreach (var i in deptCount)
            {
                Console.WriteLine(i.Dept + " - " + i.Count);
            }
            Console.WriteLine("---------------");
            Console.WriteLine("Employees Joined After 2020");
            var employeeJoined = employees.Where(x => x.JoinDate.Year > 2020);
            foreach (var i in employeeJoined)
            {
                Console.WriteLine(i.Name);
            }

            Console.WriteLine("---------------");
            Console.WriteLine("Name and AnnualSalary");
            var anual = employees.Select(x => new { Name = x.Name, AnualSalary = x.Salary * 12 }).ToList();
            foreach (var i in anual)
            {
                Console.WriteLine(i.Name + " - " + i.AnualSalary);
            }
        }


    }
}
