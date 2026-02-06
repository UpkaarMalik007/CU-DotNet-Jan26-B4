using System;
using System.IO;
using System.Runtime.Intrinsics.X86;
using System.Text;

namespace Day27_01DailyLoggerExercise
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string file = @"../../../file1.txt";
            Console.WriteLine("Write your content: ");
            string input = Console.ReadLine();

            using (StreamWriter sw = new StreamWriter(file, true))
            {
                sw.WriteLine(input);
                sw.WriteLine();
            }

            Console.WriteLine("Your reflection have been saved");


        }
    }
}
