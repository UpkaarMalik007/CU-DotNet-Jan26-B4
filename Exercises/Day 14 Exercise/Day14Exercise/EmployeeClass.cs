namespace Day14Exercise
{
    class Employee
    {
        //private data members
        int id;
        //explicit getter and setter methods
        public void SetId(int empId)
        {
            id = empId;
        }
        public int GetId()
        {
            return id;
        }

        //auto property for Name
        public string Name { get; set; }

        //full property for Department
        private string department;

        public string Department
        {
            get { return department; }
            set
            {
                if (value == "Accounts" || value == "Sales" || value == "IT")
                {
                    department = value;
                }
                else
                {
                    Console.WriteLine("Department must be Accounts, Sales, or IT.");
                }
            }

        }

        //full prop for salary between 50000 to 90000
        private int salary;

        public int Salary
        {
            get { return salary; }
            set
            {
                if (value >= 50000 && value <= 90000)
                {
                    salary = value;
                }
                else
                {
                    Console.WriteLine("Salary must be between 50000 and 90000.");
                }
            }
        }

        // Display method
        public void Display()
        {
            Console.WriteLine("Employee ID: " + id);
            Console.WriteLine("Name: " + Name);
            Console.WriteLine("Department: " + Department);
            Console.WriteLine("Salary: " + Salary);


        }
    }
    internal class EmployeeClass
    {
        static void Main(string[] args)
        {
            Employee emp = new Employee();

            emp.SetId(101);
            emp.Name = "John";
            emp.Department = "IT";
            emp.Salary = 75000;

            Console.WriteLine("Employee Details:");
            emp.Display();
        }
    }
    
}
