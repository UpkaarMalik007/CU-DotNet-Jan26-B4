namespace Assessment2Solution
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int count = 5;

            string[] policyHolderNames = new string[count];
            decimal[] annualPremiums = new decimal[count];

            Console.WriteLine("INSURANCE PREMIUM SUMMARY SYSTEM");
            Console.WriteLine("--------------------------------\n");

            // ---------- INPUT ----------
            for (int i = 0; i < count; i++)
            {
                // Name input with validation
                while (true)
                {
                    Console.Write($"Enter name of policyholder {i + 1}: ");
                    string name = Console.ReadLine();

                    if (!string.IsNullOrWhiteSpace(name))
                    {
                        policyHolderNames[i] = name;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Name cannot be empty. Please re-enter.");
                    }
                }

                // Premium input with validation
                while (true)
                {
                    Console.Write($"Enter annual premium for {policyHolderNames[i]}: ");
                    bool isValid = decimal.TryParse(Console.ReadLine(), out decimal premium);

                    if (isValid && premium > 0)
                    {
                        annualPremiums[i] = premium;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Premium must be a number greater than 0. Please re-enter.");
                    }
                }

                Console.WriteLine();
            }

            // ---------- PROCESSING ----------
            decimal total = 0;
            decimal highest = annualPremiums[0];
            decimal lowest = annualPremiums[0];

            for (int i = 0; i < count; i++)
            {
                total += annualPremiums[i];

                if (annualPremiums[i] > highest)
                    highest = annualPremiums[i];

                if (annualPremiums[i] < lowest)
                    lowest = annualPremiums[i];
            }

            decimal average = total / count;

            // ---------- OUTPUT ----------
            Console.WriteLine("\nINSURANCE SUMMARY REPORT");
            Console.WriteLine("---------------------------------------------------------------");
            Console.WriteLine("{0,-20} {1,15} {2,15}", "POLICYHOLDER", "PREMIUM", "CATEGORY");
            Console.WriteLine("---------------------------------------------------------------");

            for (int i = 0; i < count; i++)
            {
                string category;

                if (annualPremiums[i] < 10000)
                    category = "LOW";
                else if (annualPremiums[i] <= 25000)
                    category = "MEDIUM";
                else
                    category = "HIGH";

                Console.WriteLine("{0,-20} {1,15:F2} {2,15}",
                    policyHolderNames[i].ToUpper(),
                    annualPremiums[i],
                    category);
            }

            Console.WriteLine("---------------------------------------------------------------");
            Console.WriteLine($"Total Premium   : {total:F2}");
            Console.WriteLine($"Average Premium : {average:F2}");
            Console.WriteLine($"Highest Premium : {highest:F2}");
            Console.WriteLine($"Lowest Premium  : {lowest:F2}");

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }

    }
}

