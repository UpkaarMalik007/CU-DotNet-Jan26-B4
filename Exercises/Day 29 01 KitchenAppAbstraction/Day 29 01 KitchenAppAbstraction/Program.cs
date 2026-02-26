namespace Day_29_01_KitchenAppAbstraction
{
    abstract class Appliance
    {
        public string ModelName { get; set; }
        public int PowerWatts { get; set; }

        public Appliance(string modelName, int powerWatts)
        {
            ModelName = modelName;
            PowerWatts = powerWatts;
        }

        public virtual void Preheat()
        {
            Console.WriteLine($"{ModelName}: No preheating required.");
        }

        public abstract void Cook();
    }

    interface ITimer
    {
        void SetTimer(int minutes);
    }

    interface IWifiEnabled
    {
        void ConnectToWifi(string network);
    }

    class Microwave : Appliance, ITimer
    {
        public Microwave(string model, int power) : base(model, power) { }

        public void SetTimer(int minutes)
        {
            Console.WriteLine($"{ModelName}: Timer set for {minutes} minutes.");
        }

        public override void Cook()
        {
            Console.WriteLine($"{ModelName}: Microwaving food...");
        }
    }

    class ElectricOven : Appliance, ITimer, IWifiEnabled
    {
        public ElectricOven(string model, int power) : base(model, power) { }

        public override void Preheat()
        {
            Console.WriteLine($"{ModelName}: Preheating oven...");
        }

        public void SetTimer(int minutes)
        {
            Console.WriteLine($"{ModelName}: Timer set for {minutes} minutes.");
        }

        public void ConnectToWifi(string network)
        {
            Console.WriteLine($"{ModelName}: Connected to WiFi network {network}.");
        }

        public override void Cook()
        {
            Preheat();
            Console.WriteLine($"{ModelName}: Baking food...");
        }
    }

    class AirFryer : Appliance
    {
        public AirFryer(string model, int power) : base(model, power) { }

        public override void Cook()
        {
            Console.WriteLine($"{ModelName}: Air frying quickly...");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Appliance> appliances = new List<Appliance>()
            {
                new Microwave("MicroX", 1200),
                new ElectricOven("OvenPro", 2400),
                new AirFryer("AirFast", 1500)
            };

            foreach (var device in appliances)
            {
                device.Cook();
                Console.WriteLine();
            }

            ElectricOven oven = appliances[1] as ElectricOven;
            if (oven != null)
            {
                oven.ConnectToWifi("Home_WiFi");
            }

            Microwave microwave = appliances[0] as Microwave;
            if (microwave != null)
            {
                microwave.SetTimer(5);
            }
        }
    }
}
