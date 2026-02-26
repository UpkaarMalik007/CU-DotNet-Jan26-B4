namespace Day13Exercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Calling the method without any parameters
            PrintLine();
            PrintLine(ch:'$');  // named parameters
            PrintLine(60, '+');
        }
        static void PrintLine(int num = 40, char ch = '-')
        {
            for (int i = 0; i < num; i++)
            {
                Console.Write(ch);
            }
            Console.WriteLine();
        }
    }
}
