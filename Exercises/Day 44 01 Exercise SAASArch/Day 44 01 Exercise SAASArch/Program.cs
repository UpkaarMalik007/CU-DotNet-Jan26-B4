namespace Day_44_01_Exercise_SAASArch
{
    public abstract class Subscriber : IComparable<Subscriber>
    {
        public Guid ID;
        public string Name;
        public DateTime JoinDate;

        // Constructor
        public Subscriber(string name, DateTime joinDate)
        {
            ID = Guid.NewGuid();
            Name = name;
            JoinDate = joinDate;
        }

        // Abstract method (must be implemented in child class)
        public abstract decimal CalculateMonthlyBill();

        // Check equality based on ID
        public override bool Equals(object obj)
        {
            Subscriber other = obj as Subscriber;

            if (other == null)
                return false;

            return this.ID == other.ID;
        }

        // HashCode based on ID
        public override int GetHashCode()
        {
            return ID.GetHashCode();
        }

        // Compare subscribers by JoinDate, then by Name
        public int CompareTo(Subscriber other)
        {
            if (other == null)
                return 1;

            if (this.JoinDate < other.JoinDate)
                return -1;

            if (this.JoinDate > other.JoinDate)
                return 1;

            return this.Name.CompareTo(other.Name);
        }
    }
    public class BusinessSubscriber : Subscriber
    {
        public decimal FixedRate { get; set; }
        public decimal TaxRate { get; set; }

        public BusinessSubscriber(string name, DateTime joinDate,
                                  decimal fixedRate, decimal taxRate)
            : base(name, joinDate)
        {
            FixedRate = fixedRate;
            TaxRate = taxRate;
        }

        public override decimal CalculateMonthlyBill()
        {
            return FixedRate * (1 + TaxRate);
        }
    }

    public class ConsumerSubscriber : Subscriber
    {
        public decimal DataUsageGB { get; set; }
        public decimal PricePerGB { get; set; }

        public ConsumerSubscriber(string name, DateTime joinDate,
                                  decimal dataUsageGB, decimal pricePerGB)
            : base(name, joinDate)
        {
            DataUsageGB = dataUsageGB;
            PricePerGB = pricePerGB;
        }

        public override decimal CalculateMonthlyBill()
        {
            return DataUsageGB * PricePerGB;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Dictionary<string, Subscriber> dict =
                new Dictionary<string, Subscriber>();

            dict.Add("hk12", new BusinessSubscriber("Hk",
                DateTime.Parse("2024-12-12"), 14000m, 0.18m));

            dict.Add("rk21", new ConsumerSubscriber("Rk",
                DateTime.Parse("2025-11-11"), 200m, 899m));

            dict.Add("mk45", new BusinessSubscriber("Mk",
                DateTime.Parse("2023-06-01"), 10000m, 0.12m));

            dict.Add("pk78", new ConsumerSubscriber("Pk",
                DateTime.Parse("2024-03-15"), 150m, 499m));

            dict.Add("sk99", new BusinessSubscriber("Sk",
                DateTime.Parse("2022-08-20"), 20000m, 0.15m));

            // Sort by Monthly Bill (Descending)
            var sorted = dict
                .OrderByDescending(x => x.Value.CalculateMonthlyBill())
                .ToList();

            Console.WriteLine("---- Monthly Bill Report ----");

            foreach (var item in sorted)
            {
                decimal billAmount = item.Value.CalculateMonthlyBill();

                string formattedBill = "₹ " + billAmount.ToString("N2");

                Console.WriteLine(
                    $"Email: {item.Key}, Name: {item.Value.Name}, Bill: {formattedBill}");
            }
        }
    }
}

