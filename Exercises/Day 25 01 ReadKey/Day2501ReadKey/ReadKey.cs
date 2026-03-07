
namespace Day2501ReadKey
{
    internal class ReadKey
    {
        static void Main(string[] args)
        {
            string pin = "";
            int length = 4;

            Console.Write("Enter 4-digit PIN: ");

            while (pin.Length < length)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);

                
                if (char.IsDigit(key.KeyChar))
                {
                    pin += key.KeyChar;
                    Console.Write("*");
                }
                
                else if (key.Key == ConsoleKey.Backspace && pin.Length > 0)
                {
                    pin = pin.Remove(pin.Length - 1);

                    Console.Write("\b \b"); // delete last *
                }
            }

            Console.WriteLine("\n\nEntered PIN: " + pin);
        }
    }
}
