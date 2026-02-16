namespace Week5Assessment
{
    class RestrictedDestinationException : Exception
    {
        public RestrictedDestinationException(string message) : base(message)
        {

        }
    }

    class InsecurePackagingException : Exception
    {
        public InsecurePackagingException(string message) : base(message)
        {

        }
    }
    interface ILoggable
    {
        void SaveLog(string message);
    }
    abstract class Shipment
    {
        public string  TrackingId { get; set; }
        public double Weight { get; set; }
        public string Destination { get; set; }

        public List<string> RestrictedZones = new List<string> { "North Pole", "Unknown Island" };

        public abstract void ProcessShipment();
    }
    class ExpressShipment : Shipment
    {
        public bool IsFragile { get; set; }
        public bool IsReinforced { get; set; }
        public override void ProcessShipment()
        {
            if (Weight <= 0)
            {
                throw new ArgumentOutOfRangeException("Weight must be greater than 0");
            }
            if (RestrictedZones.Contains(Destination))
            {
                throw new RestrictedDestinationException($"We don't ship to Restricted Zones - {Destination}");
            }
            if(IsFragile && !IsReinforced)
            {
                throw new InsecurePackagingException("Fragile shipment must be marked Reinforced.");
            }
            Console.WriteLine($"Express shipment {TrackingId} procesed successfully.");
        }


    }

    class HeavyFreight : Shipment
    {
        public bool HasHeavyLiftPermit { get; set; }
        public override void ProcessShipment()
        {
            if (Weight <= 0)
            {
                throw new ArgumentOutOfRangeException("Weight must be greater than 0");
            }
            if (RestrictedZones.Contains(Destination))
            {
                throw new RestrictedDestinationException($"We don't ship to Restricted Zones - {Destination}");
            }
            if(Weight>1000 && !HasHeavyLiftPermit)
            {
                throw new Exception("Heavy Lift permit is required for the weigth above 1000kg");
            }

            Console.WriteLine($"Express Shipment {TrackingId} processed Successfully.");
        }
    }
    class LogManager : ILoggable
    {
        public string fileName = @"../../../shipment_audit.log";
        
        public void SaveLog(string message)
        {
            using(StreamWriter sw=new StreamWriter(fileName, true))
            {
                sw.WriteLine(message);
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            LogManager details = new LogManager();
            List<Shipment> shipments = new List<Shipment>()
            {
                new ExpressShipment
                {
                    TrackingId="T101",
                    Weight=500,
                    Destination="New York",
                    IsFragile=true,
                    IsReinforced=true
                },
                new ExpressShipment
                {
                    TrackingId="T102",
                    Weight=550,
                    Destination="Delhi",
                    IsFragile=true,
                    IsReinforced=false
                },
                new ExpressShipment
                {
                    TrackingId="T103",
                    Weight=400,
                    Destination="North Pole",
                },
                new HeavyFreight
                {
                    TrackingId="T108",
                    Weight=1000,
                    Destination="Bangkok",
                    HasHeavyLiftPermit=true
                },
                new HeavyFreight
                {
                    TrackingId="T119",
                    Weight=1000,
                    Destination="New Jersey",
                    HasHeavyLiftPermit=false
                },
                new HeavyFreight
                {
                    TrackingId="T016",
                    Weight=1000,
                    Destination="North Pole",
                    HasHeavyLiftPermit=true
                }
            };

            foreach(var shipment in shipments)
            {
                try
                {
                    shipment.ProcessShipment();
                    details.SaveLog($"Success: Shipment {shipment.TrackingId} processed.");
                    
                }
                catch(ArgumentOutOfRangeException ex)
                {
                    details.SaveLog($"DATA ENTRY ERROR: {ex.Message}");
                    
                }
                catch(RestrictedDestinationException ex)
                {
                    details.SaveLog($"SECURITY ALERT: {ex.Message}");
                }
                catch(Exception ex)
                {
                    details.SaveLog($"GENERAL ERROR: {ex.Message}");
                }
                finally
                {
                    Console.WriteLine($"Processing attempt finished for {shipment.TrackingId}");
                }

            }
        }
    }
}
