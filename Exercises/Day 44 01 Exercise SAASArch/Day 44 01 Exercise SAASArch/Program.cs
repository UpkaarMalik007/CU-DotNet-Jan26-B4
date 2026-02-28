namespace Day_44_01_Exercise_SAASArch
{
    abstract class Subscriber
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public DateTime MyProperty { get; set; }

        public abstract decimal CalculateMonthlyBill();
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}
