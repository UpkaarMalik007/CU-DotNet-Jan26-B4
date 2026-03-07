namespace Day10Exercise
{
    internal class MethodOperator
    {
        static void Main(string[] args)
        {
            decimal[] sales = new decimal[7];
            string[] categories = new string[7];

            ReadWeeklySales(sales);

            decimal total = CalculateTotal(sales);
            decimal average = CalculateAverage(total, sales.Length);

            int highDay, lowDay;
            decimal highest = FindHighestSale(sales, out highDay);
            decimal lowest = FindLowestSale(sales, out lowDay);

            Console.Write("Is this a festival week? (true/false): ");
            bool isFestivalWeek = bool.Parse(Console.ReadLine());

            decimal discount = CalculateDiscount(total, isFestivalWeek);
            decimal tax = CalculateTax(total - discount);
            decimal finalAmount = CalculateFinalAmount(total, discount, tax);

            GenerateSalesCategory(sales, categories);

            // -------- OUTPUT --------
            Console.WriteLine("\nWeekly Sales Summary");
            Console.WriteLine("--------------------");
            Console.WriteLine($"Total Sales        : {total:F2}");
            Console.WriteLine($"Average Daily Sale : {average:F2}\n");

            Console.WriteLine($"Highest Sale       : {highest:F2} (Day {highDay})");
            Console.WriteLine($"Lowest Sale        : {lowest:F2}  (Day {lowDay})\n");

            Console.WriteLine($"Discount Applied   : {discount:F2}");
            Console.WriteLine($"Tax Amount         : {tax:F2}");
            Console.WriteLine($"Final Payable      : {finalAmount:F2}\n");

            Console.WriteLine("Day-wise Category:");
            for (int i = 0; i < categories.Length; i++)
            {
                Console.WriteLine($"Day {i + 1} : {categories[i]}");
            }
        }
        // 1. Read weekly sales
        static void ReadWeeklySales(decimal[] sales)
        {
            for (int i = 0; i < sales.Length; i++)
            {
                while (true)
                {
                    Console.Write($"Enter sale for Day {i + 1}: ");
                    decimal value = decimal.Parse(Console.ReadLine());

                    if (value >= 0)
                    {
                        sales[i] = value;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Sales cannot be negative. Try again.");
                    }
                }
            }
        }

        // 2. Total
        static decimal CalculateTotal(decimal[] sales)
        {
            decimal sum = 0;
            for (int i = 0; i < sales.Length; i++)
                sum += sales[i];

            return sum;
        }

        // 2. Average
        static decimal CalculateAverage(decimal total, int days)
        {
            return total / days;
        }

        // 3. Highest
        static decimal FindHighestSale(decimal[] sales, out int day)
        {
            decimal max = sales[0];
            day = 1;

            for (int i = 1; i < sales.Length; i++)
            {
                if (sales[i] > max)
                {
                    max = sales[i];
                    day = i + 1;
                }
            }
            return max;
        }

        // 3. Lowest
        static decimal FindLowestSale(decimal[] sales, out int day)
        {
            decimal min = sales[0];
            day = 1;

            for (int i = 1; i < sales.Length; i++)
            {
                if (sales[i] < min)
                {
                    min = sales[i];
                    day = i + 1;
                }
            }
            return min;
        }

        // 4. Discount (normal)
        static decimal CalculateDiscount(decimal total)
        {
            if (total >= 50000)
                return total * 0.10m;
            else
                return total * 0.05m;
        }

        // 4. Discount (festival overload)
        static decimal CalculateDiscount(decimal total, bool isFestivalWeek)
        {
            decimal discount = CalculateDiscount(total);

            if (isFestivalWeek)
                discount += total * 0.05m;

            return discount;
        }

        // 5. Tax
        static decimal CalculateTax(decimal amount)
        {
            return amount * 0.18m;
        }

        // 6. Final amount
        static decimal CalculateFinalAmount(decimal total, decimal discount, decimal tax)
        {
            return (total - discount) + tax;
        }

        // 7. Category
        static void GenerateSalesCategory(decimal[] sales, string[] categories)
        {
            for (int i = 0; i < sales.Length; i++)
            {
                if (sales[i] < 5000)
                    categories[i] = "Low";
                else if (sales[i] <= 15000)
                    categories[i] = "Medium";
                else
                    categories[i] = "High";
            }

        }
    }
}
