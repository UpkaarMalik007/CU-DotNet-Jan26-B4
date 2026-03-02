namespace Day_43_01_Exercise_Financial_Portfolio
{

    public class InvalidFinancialDataException : Exception
    {
        public InvalidFinancialDataException(string message) : base(message) { }
    }

    public interface IRiskAssessable
    {
        string GetRiskCategory();
    }

    public interface IReportable
    {
        string GenerateReportLine();
    }

    public abstract class FinancialInstrument
    {
        private decimal _quantity;
        private decimal _purchasePrice;
        private decimal _marketPrice;
        private string _currency;

        public string InstrumentId { get; set; }
        public string Name { get; set; }
        public DateTime PurchaseDate { get; set; }

        public decimal Quantity
        {
            get => _quantity;
            set
            {
                if (value < 0)
                    throw new InvalidFinancialDataException("Quantity cannot be negative");
                _quantity = value;
            }
        }

        public decimal PurchasePrice
        {
            get => _purchasePrice;
            set
            {
                if (value < 0)
                    throw new InvalidFinancialDataException("Purchase price cannot be negative");
                _purchasePrice = value;
            }
        }

        public decimal MarketPrice
        {
            get => _marketPrice;
            set
            {
                if (value < 0)
                    throw new InvalidFinancialDataException("Market price cannot be negative");
                _marketPrice = value;
            }
        }

        public string Currency
        {
            get => _currency;
            set
            {
                if (value.Length != 3)
                    throw new InvalidFinancialDataException("Currency must be 3-letter code");
                _currency = value.ToUpper();
            }
        }

        public decimal TotalInvestment => Quantity * PurchasePrice;

        public abstract decimal CalculateCurrentValue();

        public virtual string GetInstrumentSummary()
        {
            return $"{InstrumentId} - {Name} | Investment: {TotalInvestment:C} | Current: {CalculateCurrentValue():C}";
        }
    }

    public class Equity : FinancialInstrument, IRiskAssessable, IReportable
    {
        public override decimal CalculateCurrentValue()
            => Quantity * MarketPrice;

        public string GetRiskCategory() => "High";

        public string GenerateReportLine()
            => $"{InstrumentId}, Equity, {Name}, {CalculateCurrentValue():C}";
    }

    public class Bond : FinancialInstrument, IRiskAssessable, IReportable
    {
        public override decimal CalculateCurrentValue()
            => Quantity * MarketPrice;

        public string GetRiskCategory() => "Low";

        public string GenerateReportLine()
            => $"{InstrumentId}, Bond, {Name}, {CalculateCurrentValue():C}";
    }

    public class FixedDeposit : FinancialInstrument
    {
        public override decimal CalculateCurrentValue()
            => Quantity * MarketPrice;
    }

    public class MutualFund : FinancialInstrument, IRiskAssessable
    {
        public override decimal CalculateCurrentValue()
            => Quantity * MarketPrice;

        public string GetRiskCategory() => "Medium";
    }


    
    public class Transaction
    {
        public string TransactionId { get; set; }
        public string InstrumentId { get; set; }
        public string Type { get; set; } // Buy / Sell
        public decimal Units { get; set; }
        public DateTime Date { get; set; }
    }

    public class Portfolio
    {
        private List<FinancialInstrument> instruments = new();
        private Dictionary<string, FinancialInstrument> instrumentLookup = new();

        public void AddInstrument(FinancialInstrument instrument)
        {
            if (instrumentLookup.ContainsKey(instrument.InstrumentId))
                throw new Exception("Duplicate Instrument ID");

            instruments.Add(instrument);
            instrumentLookup[instrument.InstrumentId] = instrument;
        }

        public void RemoveInstrument(string id)
        {
            if (instrumentLookup.ContainsKey(id))
            {
                instruments.Remove(instrumentLookup[id]);
                instrumentLookup.Remove(id);
            }
        }

        public FinancialInstrument GetInstrumentById(string id)
            => instrumentLookup.ContainsKey(id) ? instrumentLookup[id] : null;

        public decimal GetTotalPortfolioValue()
            => instruments.Sum(i => i.CalculateCurrentValue());

        public IEnumerable<FinancialInstrument> GetInstrumentsByRisk(string risk)
        {
            return instruments
                .OfType<IRiskAssessable>()
                .Where(i => i.GetRiskCategory() == risk)
                .Cast<FinancialInstrument>();
        }

        public IEnumerable<IGrouping<string, FinancialInstrument>> GroupByType()
            => instruments.GroupBy(i => i.GetType().Name);

        public List<FinancialInstrument> GetAll() => instruments;
    }
    
    public class ReportGenerator
    {
        public void GenerateConsoleReport(Portfolio portfolio)
        {
            Console.WriteLine("===== PORTFOLIO SUMMARY =====\n");

            foreach (var group in portfolio.GroupByType())
            {
                decimal totalInvestment = group.Sum(i => i.TotalInvestment);
                decimal currentValue = group.Sum(i => i.CalculateCurrentValue());

                Console.WriteLine($"Instrument Type: {group.Key}");
                Console.WriteLine($"Total Investment: {totalInvestment:C}");
                Console.WriteLine($"Current Value: {currentValue:C}");
                Console.WriteLine($"Profit/Loss: {(currentValue - totalInvestment):C}\n");
            }

            Console.WriteLine($"Overall Portfolio Value: {portfolio.GetTotalPortfolioValue():C}");

            var riskDistribution = portfolio.GetAll()
                .OfType<IRiskAssessable>()
                .GroupBy(r => r.GetRiskCategory());

            Console.WriteLine("\nRisk Distribution:");
            foreach (var risk in riskDistribution)
                Console.WriteLine($"{risk.Key}: {risk.Count()}");
        }

        public void GenerateFileReport(Portfolio portfolio)
        {
            string fileName = $"PortfolioReport_{DateTime.Now:yyyyMMdd}.txt";

            try
            {
                using StreamWriter writer = new StreamWriter(fileName);

                writer.WriteLine("===== PORTFOLIO REPORT =====");
                writer.WriteLine($"Generated On: {DateTime.Now}");
                writer.WriteLine();

                foreach (var instrument in portfolio.GetAll())
                {
                    writer.WriteLine(instrument.GetInstrumentSummary());
                }

                writer.WriteLine();
                writer.WriteLine($"Total Portfolio Value: {portfolio.GetTotalPortfolioValue():C}");
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("File write permission error.");
            }
        }
    }

    internal class Program
    {
        static void Main()
        {
            Portfolio portfolio = new Portfolio();

            // CSV Parsing Example
            string csv = "EQ001,Equity,INFY,INR,100,1500,1650";
            string[] parts = csv.Split(',');

            FinancialInstrument equity = new Equity
            {
                InstrumentId = parts[0],
                Name = parts[2],
                Currency = parts[3],
                Quantity = decimal.Parse(parts[4]),
                PurchasePrice = decimal.Parse(parts[5]),
                MarketPrice = decimal.Parse(parts[6]),
                PurchaseDate = DateTime.Now
            };

            portfolio.AddInstrument(equity);

            // Transactions Array
            Transaction[] transactionsArray =
            {
                new Transaction { TransactionId="T1", InstrumentId="EQ001", Type="Buy", Units=10, Date=DateTime.Now }
            };

            List<Transaction> transactions = transactionsArray.ToList();

            foreach (var t in transactions)
            {
                var instrument = portfolio.GetInstrumentById(t.InstrumentId);
                if (instrument != null)
                {
                    if (t.Type == "Buy")
                        instrument.Quantity += t.Units;
                    else if (t.Type == "Sell")
                    {
                        if (instrument.Quantity < t.Units)
                            throw new Exception("Cannot sell more than owned");
                        instrument.Quantity -= t.Units;
                    }
                }
            }

            ReportGenerator report = new ReportGenerator();
            report.GenerateConsoleReport(portfolio);
            report.GenerateFileReport(portfolio);
        }
    }
}
