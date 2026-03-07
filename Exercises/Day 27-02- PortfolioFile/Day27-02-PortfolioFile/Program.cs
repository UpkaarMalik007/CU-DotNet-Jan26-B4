using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Day27_02_PortfolioFile
{
    class Loan
    {
        public string ClientName { get; set; }
        public double Principal { get; set; }
        public double InterestRate { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            string file = @"..\..\..\loan.csv";

            Console.Write("Enter Client Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Principal Amount: ");
            double principal = double.Parse(Console.ReadLine());

            Console.Write("Enter Interest Rate: ");
            double rate = double.Parse(Console.ReadLine());

            bool fileExists = File.Exists(file);
            using (StreamWriter sw = new StreamWriter(file, true))
            {
                if (!fileExists)
                {
                    sw.WriteLine("ClientName, Principal, Interest");
                }
                sw.WriteLine($"{name},{principal},{rate}");
            }

            List<Loan> loans = new List<Loan>();
            Console.OutputEncoding = Encoding.UTF8;
            using(StreamReader sr=new StreamReader(file))
            {
                sr.ReadLine();
                do
                {
                    string line = sr.ReadLine();
                    if (line == null) break;
                    string[] input = line.Split(',');
                    string clientName = input[0];
                    if (double.TryParse(input[1],out double p) && double.TryParse(input[2],out double r)){
                        loans.Add(new Loan { ClientName = clientName, Principal = p, InterestRate = r });
                    }

                } while (true);
            }


            Console.WriteLine("Loan Portfolio");

            Console.WriteLine("ClientName  | Principal   | InterestRate |  Risk Level ");

            foreach(Loan loan in loans)
            {
                double interestRate = loan.Principal * loan.InterestRate / 100;
                string risk = string.Empty;
                if (loan.InterestRate > 10) risk = "HIGH";
                else if (loan.InterestRate >= 5 && loan.InterestRate <= 10) risk = "MEDIUM";
                else risk = "LOW";

                Console.WriteLine($"{loan.ClientName,-12}| {loan.Principal,-12:C2}| {interestRate,-13:C2}| {risk,-10}");
            }
            


        }
    }
}
