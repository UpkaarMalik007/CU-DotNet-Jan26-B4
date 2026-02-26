namespace Day_22_01_OLADriver
{
    class Ride
    {
        public int RideID { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public double Fare { get; set; }

        public Ride(int rideID, string from, string to, double fare)
        {
            RideID = rideID;
            From = from;
            To = to;
            Fare = fare;
        }
    }

    class OLADriver
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string VehicleNo { get; set; }
        public List<Ride> Rides { get; set; }

        public OLADriver(int id, string name, string vehicleNo)
        {
            Id = id;
            Name = name;
            VehicleNo = vehicleNo;
            Rides = new List<Ride>();
        }

        public void AddRide(Ride ride)
        {
            Rides.Add(ride);
        }

        public double GetTotalFare()
        {
            double total = 0;
            foreach (var ride in Rides)
            {
                total += ride.Fare;
            }
            return total;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<OLADriver> drivers = new List<OLADriver>();

            OLADriver d1 = new OLADriver(1, "Aman", "DL01AB1234");
            d1.AddRide(new Ride(101, "Delhi", "Noida", 350));
            d1.AddRide(new Ride(102, "Noida", "Gurgaon", 420));

            OLADriver d2 = new OLADriver(2, "Rahul", "DL02CD5678");
            d2.AddRide(new Ride(201, "Delhi", "Faridabad", 300));
            d2.AddRide(new Ride(202, "Faridabad", "Delhi", 280));
            d2.AddRide(new Ride(203, "Delhi", "Meerut", 500));

            drivers.Add(d1);
            drivers.Add(d2);

            foreach (var driver in drivers)
            {
                Console.WriteLine("Driver: " + driver.Name);
                Console.WriteLine("Vehicle: " + driver.VehicleNo);

                foreach (var ride in driver.Rides)
                {
                    Console.WriteLine("RideID: " + ride.RideID +
                                      " | From: " + ride.From +
                                      " | To: " + ride.To +
                                      " | Fare: " + ride.Fare);
                }

                Console.WriteLine("Total Fare: " + driver.GetTotalFare());
                Console.WriteLine("-----------------------------");
            }
        }
    }
}
