namespace Day9Assignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            decimal[] dailySales = new decimal[7];
            string[] salesCategory = new string[7];

            Console.WriteLine("Weekly Sales Analysis System\n");

            // -------- INPUT --------
            for (int i = 0; i < dailySales.Length; i++)
            {
                while (true)
                {
                    Console.Write($"Enter sales for Day {i + 1}: ");
                    decimal value;

                    if (decimal.TryParse(Console.ReadLine(), out value) && value >= 0)
                    {
                        dailySales[i] = value;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Sales must be >= 0.");
                    }
                }
            }

            // -------- PROCESSING --------
            decimal total = 0;
            decimal highest = dailySales[0];
            decimal lowest = dailySales[0];
            int highestDay = 1;
            int lowestDay = 1;

            for (int i = 0; i < dailySales.Length; i++)
            {
                total += dailySales[i];

                if (dailySales[i] > highest)
                {
                    highest = dailySales[i];
                    highestDay = i + 1;
                }

                if (dailySales[i] < lowest)
                {
                    lowest = dailySales[i];
                    lowestDay = i + 1;
                }
            }

            decimal average = total / dailySales.Length;

            int daysAboveAverage = 0;
            for (int i = 0; i < dailySales.Length; i++)
            {
                if (dailySales[i] > average)
                    daysAboveAverage++;
            }

            // -------- CATEGORIZATION --------
            for (int i = 0; i < dailySales.Length; i++)
            {
                if (dailySales[i] < 5000)
                    salesCategory[i] = "Low";
                else if (dailySales[i] <= 15000)
                    salesCategory[i] = "Medium";
                else
                    salesCategory[i] = "High";
            }

            // -------- OUTPUT --------
            Console.WriteLine("\nWeekly Sales Report");
            Console.WriteLine("-------------------");
            Console.WriteLine($"Total Sales        : {total:F2}");
            Console.WriteLine($"Average Daily Sale : {average:F2}\n");

            Console.WriteLine($"Highest Sale       : {highest:F2} (Day {highestDay})");
            Console.WriteLine($"Lowest Sale        : {lowest:F2}  (Day {lowestDay})\n");

            Console.WriteLine($"Days Above Average : {daysAboveAverage}\n");

            Console.WriteLine("Day-wise Sales Category");
            for (int i = 0; i < salesCategory.Length; i++)
            {
                Console.WriteLine($"Day {i + 1} : {salesCategory[i]}");
            }

            Console.ReadKey();
            //ReadKey() forces the program to wait until the user presses any key, so you get time to read the result.
        }
    }
}
