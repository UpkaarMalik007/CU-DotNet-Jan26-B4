namespace Day18ExercisePart1

{
    class Loan
    {
        public string LoanNumber { get; set; }
        public string CustomerName { get; set; }
        public decimal PrincipalAmount { get; set; }
        public int TenureInYears { get; set; }



        public Loan()
        {
            LoanNumber = string.Empty;
            CustomerName = string.Empty;
        }
        public Loan(string loanNumber, string customerName, decimal principalAmount, int tenure)
        {
            LoanNumber = loanNumber;
            CustomerName = customerName;
            PrincipalAmount = principalAmount;
            TenureInYears = tenure;
        }

        public double CalculateEMI()
        {
            double emi = ((double)(PrincipalAmount) * 10 * (double)TenureInYears) / 100d;
            return emi;
        }

        public override string ToString()
        {
            return $"{LoanNumber} {CustomerName}";
        }
    }

    class HomeLoan : Loan
    {
        public HomeLoan(string loanNumber, string customerName, decimal principalAmount, int tenure) :
            base(loanNumber, customerName, principalAmount, tenure)
        {

        }

        public new string CalculateEMI()

        {
            Console.WriteLine("home loan");
            double emi = (((double)(PrincipalAmount) * 0.01) * 8 * (double)TenureInYears) / 100d;
            return base.ToString() + $"{emi}";
        }
    }

    class CarLoan : Loan
    {
        public CarLoan(string loanNumber, string customerName, decimal principalAmount, int tenure) :
            base(loanNumber, customerName, principalAmount, tenure)
        {

        }
        int insurance = 15000;
        public new string CalculateEMI()
        {
            Console.WriteLine("car loan");
            double emi = ((double)(PrincipalAmount + insurance) * 9 * (double)TenureInYears) / 100d;
            return base.ToString() + $"{emi}";
        }
    }
    internal class LoanInheritance
    {
        static void Main(string[] args)
        {
            Loan[] lo =
            {
                new Loan("123", "hig", 986, 2),
                new HomeLoan("456", "haag", 986, 2),
                new HomeLoan("789", "poig", 988996, 2),
                new CarLoan("104", "uig", 986, 2),
            };

            for (int i = 0; i < lo.Length; i++)
            {
                Console.WriteLine($"Loan Number- {lo[i].LoanNumber} | Customer Name- {lo[i].CustomerName} | Emi-{lo[i].CalculateEMI()}");
            }




        }
    }
}
