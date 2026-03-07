using GreetingLibrary;

namespace GreetingAPP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your name:");
            string name = Console.ReadLine();

            string message = GreetingHelper.GetGreeting(name);

            Console.WriteLine(message);
            Console.ReadLine();
        }
    }
}
