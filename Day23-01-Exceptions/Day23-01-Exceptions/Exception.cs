using System.Linq.Expressions;

namespace Day23_01_Exceptions
{
    public class InvalidStudentAgeException: System.Exception
    {
        public InvalidStudentAgeException(string message) : base(message)
        {

        }
    }

    public class InvalidStudentNameException : System.Exception
    {
        public InvalidStudentNameException(string message) : base(message)
        {

        }
    }


    internal class Exception
    {
        static void Main(string[] args)
        {
            //Built-In Exception Handling
            HandleDivision();
            HandleConversion();
            HandleOutOfBound();

            //Custom ExceptionHandling
            int age = GetValidAge();
            string name = GetValidName();

            //Inner Exception
            DemonstrateInnerException();
        }
        static void HandleDivision()
        {
            try
            {
                Console.Write("Enter First Number: ");
                int a = int.Parse(Console.ReadLine());

                Console.Write("Enter second Number: ");
                int b = int.Parse(Console.ReadLine());

                int result = a / b;
                Console.WriteLine($"Result: {result}");

            }
            catch(DivideByZeroException ex)
            {
                Console.WriteLine("Error: Can't divide by zero");
                Console.WriteLine($"Message:{ex.Message}");
            }
            finally
            {
                Console.WriteLine("Division Operation Completed");
            }
        }

        static void HandleConversion()
        {
            try
            {
                Console.WriteLine("Enter a number to convert to integer: ");
                string input = Console.ReadLine();
                int num = Convert.ToInt32(input);
                Console.WriteLine($"You Entered a Number: {num}");
            }
            catch(FormatException ex)
            {
                Console.WriteLine("Error: Invalid Format.Please enter a numeric value");
                Console.WriteLine($"Message: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Conversion Operation Completed.");
            }
        }
        static void HandleOutOfBound()
        {
            int[] arr = { 10, 23, 45, 76, 98};
            try
            {
                Console.WriteLine("Enter index to access:(0-4)");
                int num = int.Parse(Console.ReadLine());
                Console.WriteLine($"Array element at index: {arr[num]}");
            }
            catch(IndexOutOfRangeException ex)
            {
                Console.WriteLine("Error.Index Out Of Range.");
                Console.WriteLine($"Message: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Array access completed successfully.");
            }
        }

        static int GetValidAge()
        {
            int age;
            while (true)
            {
                try
                {
                    Console.WriteLine("Enter Valid Age:(18-60)");
                    age = int.Parse(Console.ReadLine());
                    if(age<18 || age > 60)
                        throw new InvalidStudentAgeException("Age must be between 18 and 60.");
                    break;
                }
                catch(InvalidStudentAgeException ex)
                {
                    Console.WriteLine($"Invalid Age: {ex.Message}");
                }
                catch(FormatException)
                {
                    Console.WriteLine("Invalid Input.Please enter a valid number.");
                }
            }
            return age;
        }

        static string GetValidName()
        {
            string name;
            while (true)
            {
                try
                {
                    Console.WriteLine("Enter name(Characters<6)");
                    name = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(name) || name.Length < 3)
                        throw new InvalidStudentNameException("Name should have atmost 5 characters.");
                    break;
                }
                catch(InvalidStudentNameException ex)
                {
                    Console.WriteLine($"Invalid Name: {ex.Message}");
                }
            }
            
            return name;
        }

        static void DemonstrateInnerException()
        {
            try
            {
                try
                {
                    throw new InvalidStudentAgeException("Age cannot be less than 18."); // inner
                }
                catch (InvalidStudentAgeException ex)
                {
                    
                    throw new ApplicationException("Student registration failed.", ex);
                }
            }
            catch (ApplicationException ex)
            {
                Console.WriteLine("\n=== Inner Exception Demonstration ===");
                Console.WriteLine($"Outer Exception Message: {ex.Message}");
                Console.WriteLine($"Inner Exception Message: {ex.InnerException.Message}");

                
                Console.WriteLine("\n=== Exception Logging ===");
                Console.WriteLine($"Message: {ex.Message}");
                Console.WriteLine($"StackTrace: {ex.StackTrace}");
                Console.WriteLine($"InnerException: {ex.InnerException}");
            }
        }
    }
}
