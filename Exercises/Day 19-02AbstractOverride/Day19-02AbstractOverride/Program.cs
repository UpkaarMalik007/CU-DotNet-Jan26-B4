namespace Day19_02AbstractOverride
{
    abstract class UtilityBill
    {
        public int ConsumerId { get; set; }
        public string ConsumerName { get; set; }
        public decimal UnitsConsumed { get; set; }
        public decimal RatePerUnit { get; set; }

        protected UtilityBill(int id,string name,decimal units,decimal rate)
        {
            ConsumerId = id;
            ConsumerName = name;
            UnitsConsumed = units;
            RatePerUnit = rate;
        }

        public abstract decimal CalculateBillAmount();

        public virtual decimal CalculateTax(decimal billAmount)
        {
            return billAmount * 0.05m;
            
        }

        public void PrintBill()
        {
            decimal billAmount = CalculateBillAmount();
            decimal tax = CalculateTax(billAmount);
            decimal finalAmount = billAmount + tax;

            Console.WriteLine("__Utility Bill__");
            Console.WriteLine($"Consumer Id: {ConsumerId}");
            Console.WriteLine($"Consumer Name: {ConsumerName}");
            Console.WriteLine($"Units Consumed: {UnitsConsumed}");
            Console.WriteLine($"Final Amount: {finalAmount}");
        }
    }

    class ElectricityBill : UtilityBill
    {
        public ElectricityBill(int id, string name, decimal units, decimal rate):base(id,name,units,rate)
        {
            ConsumerId = id;
            ConsumerName = name;
            UnitsConsumed = units;
            RatePerUnit = rate;
        }

        public override decimal CalculateBillAmount()
        {
            decimal billAmount = UnitsConsumed * RatePerUnit;
            if (UnitsConsumed > 300)
            {
                billAmount += billAmount * 0.1m;
            }
            return billAmount;
        }
        //Do not override CalculateTax
    }
    class WaterBill : UtilityBill
    {
        public WaterBill(int id, string name, decimal units, decimal rate):base(id,name,units,rate)
        {
            ConsumerId = id;
            ConsumerName = name;
            UnitsConsumed = units;
            RatePerUnit = rate;
        }
        public override decimal CalculateBillAmount()
        {
            return RatePerUnit * UnitsConsumed;
        }

        public override decimal CalculateTax(decimal billAmount)
        {
            return billAmount * 0.02m;
        }
        
    }
    class GasBill : UtilityBill
    {
        public GasBill(int id, string name, decimal units, decimal rate) : base(id, name, units, rate)
        {
            ConsumerId = id;
            ConsumerName = name;
            UnitsConsumed = units;
            RatePerUnit = rate;
        }

        public override decimal CalculateBillAmount()
        {
            return RatePerUnit * UnitsConsumed;
        }

        public override decimal CalculateTax(decimal billAmount)
        {
            return 0m;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<UtilityBill> bills = new List<UtilityBill>();

            bills.Add(new ElectricityBill(101, "Amit", 350, 6.5m));
            bills.Add(new WaterBill(102, "Rahul", 200, 4.0m));
            bills.Add(new GasBill(103, "Sita", 150, 5.0m));

            foreach (var bill in bills)
            {
                bill.PrintBill();
            }
        }
    }
}
