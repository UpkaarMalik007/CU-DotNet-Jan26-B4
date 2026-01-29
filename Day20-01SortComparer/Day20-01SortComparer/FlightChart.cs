namespace Day20_01SortComparer
{
    class Flight:IComparable<Flight>
    {
        public string FlightNumber { get; set; }
        public decimal Price { get; set; }
        public TimeSpan  Duration { get; set; }
        public DateTime DepartureTime { get; set; }

        public int CompareTo(Flight? other)
        {
            return this.Price.CompareTo(other?.Price);
        }

        public override string ToString()
        {
            return $"FlightNumber={FlightNumber} | Price={Price} | Duration={Duration} | DepartureTime={DepartureTime}";
        }
    }

    class DurationComparer : IComparer<Flight>
    {
        public int Compare(Flight? x, Flight? y)
        {
            return x!.Duration.CompareTo(y!.Duration);
        }
    }

    class DepartureComparer : IComparer<Flight>
    {
        public int Compare(Flight? x, Flight? y)
        {
            return x!.DepartureTime.CompareTo(y!.DepartureTime);
        }
    }

    internal class FlightChart
    {
        static void Main(string[] args)
        {
            List<Flight> flights = new List<Flight>
            {
                new Flight{FlightNumber="A101",Price=5000,Duration=new TimeSpan(0, 90,0),DepartureTime=DateTime.Parse("2026-02-01 06:30")},
                new Flight{FlightNumber="B102",Price=10000,Duration=new TimeSpan(0,120,0),DepartureTime=DateTime.Parse("2026-02-01 05:45")},
                new Flight{FlightNumber="D301",Price=6000,Duration=new TimeSpan(0,60,0),DepartureTime=DateTime.Parse("2026-02-02 09:50")}
            };

            flights.Sort();
            Console.WriteLine("1. Economic View: Cheapest flights at the top");
            foreach(Flight f1 in flights)
            {
                Console.WriteLine(f1);
            }
            Console.WriteLine();

            flights.Sort(new DurationComparer());
            Console.WriteLine("2. Business Runner View: Shortest flights at the top.");
            foreach(var f1 in flights)
            {
                Console.WriteLine(f1);
            }
            Console.WriteLine();

            flights.Sort(new DepartureComparer());
            Console.WriteLine("3. Early Bird View: Earliest departing flights at the top.");
            foreach(var f1 in flights)
            {
                Console.WriteLine(f1);
            }
        }
    }
}
