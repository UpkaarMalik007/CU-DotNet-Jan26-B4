namespace Day18ExercisePart2
{
    class Employee
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public decimal BasicSalary { get; set; }
        public int ExperienceInYears { get; set; }
        public int Bonus;

        public Employee(int id,string name,decimal salary, int experience)
        {
            EmployeeId = id;
            EmployeeName = name;
            BasicSalary = salary;
            ExperienceInYears = experience;

        }

        public decimal CalculateAnnualSalary()
        {
            decimal AnnualSalary = BasicSalary * 12;
            return AnnualSalary;
        }

        public void Display()
        {
            Console.WriteLine($"Id - {EmployeeId} Name - {EmployeeName} Salary - {CalculateAnnualSalary()} Experience - {ExperienceInYears} ");
        }

    }
    class PermanentEmployee: Employee
    {
        decimal HouseRentAllowance;
        decimal SpecialAllowance;
        public PermanentEmployee(int id,string name,decimal salary,int experience):
            base(id,name,salary,experience)
        {

        }
        public new decimal CalculateAnnualSalary()
        {
            decimal AnnualSalary = BasicSalary * 12;
            HouseRentAllowance = BasicSalary * 0.2m;
            SpecialAllowance = BasicSalary * 0.1m;

            if (ExperienceInYears >= 5)
            {
                Bonus = 50000;
            }
            AnnualSalary += HouseRentAllowance + SpecialAllowance + Bonus;
            return AnnualSalary;
        }


    }

    class ContractEmployee : Employee
    {
        public int ContractDurationMonths { get; set; }
        public ContractEmployee(int id, string name, decimal salary, int experience) :
            base(id, name, salary, experience)
        {

        }
        public new decimal CalculateAnnualSalary()
        {
            if (ContractDurationMonths >= 12)
            {
                Bonus = 30000;
            }
            decimal AnnualSalary = BasicSalary * 12 + Bonus;
            return AnnualSalary;
        }


    }
    class InternEmployee : Employee
    {
        public InternEmployee(int id, string name, decimal salary, int experience) :
            base(id, name, salary, experience)
        {

        }

        public new decimal CalculateAnnualSalary()
        {
            decimal AnnualSalary = BasicSalary * 12;
            return AnnualSalary;
        }

    }

    internal class EmployeeInheritance
    {
        static void Main(string[] args)
        {
            Employee emp1 = new Employee(1, "Krish", 33000, 5);
            PermanentEmployee emp2 = new PermanentEmployee(2, "Ishan", 5000, 4);
            ContractEmployee emp3 = new ContractEmployee(3, "Kush", 10000, 3)
            {
                ContractDurationMonths = 14
            };

            InternEmployee emp4 = new InternEmployee(7, "Harsh", 20000, 0);
            Console.WriteLine(emp1.CalculateAnnualSalary()); //Base Method
            emp1.Display();
            Console.WriteLine(emp2.CalculateAnnualSalary());//Derived Method
            Console.WriteLine(emp3.CalculateAnnualSalary());
            Console.WriteLine(emp4.CalculateAnnualSalary());


        }
    }
}
