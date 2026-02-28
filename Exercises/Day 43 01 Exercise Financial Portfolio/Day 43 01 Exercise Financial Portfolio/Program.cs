namespace Day_43_01_Exercise_Financial_Portfolio
{
    abstract class FinancialInstrument
    {
        public int InstrumentId { get; set; }
        public string? Name { get; set; }
        public int Currency { get; set; }
        public DateOnly PurchaseDate { get; set; }
        public int Quantity { get; set; }
        public int PurchasePrice { get; set; }
        public int MarketPrice { get; set; }

        public abstract decimal CalculateCurrentValue();
        public virtual string GetInstrumentSummary()
        {

        }
    }
    interface IRiskAssessable
    {
        string GetRiskCategory();
    }
    interface IReportable
    {
        string GenerateReportLine();
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}
