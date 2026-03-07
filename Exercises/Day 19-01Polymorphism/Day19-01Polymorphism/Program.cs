namespace Day19_01Polymorphism
{
    abstract class Vehicle
    {
        public string ModelName { get; set; }
        
        protected Vehicle(string model)
        {
            ModelName = model;
        }
        public abstract void Move();
        
        public virtual string GetFuelStatus()
        {
            return $"Fuel Level is Stable";
        }
    }

    class ElectricCar : Vehicle
    {
        public ElectricCar(string name):base(name)
        {
            ModelName = name;
        }
        public override void Move()
        {
            Console.WriteLine($"{ModelName} is gliding silently on battery power.");
        }

        public override string GetFuelStatus()
        {
            return $"{ModelName} battery is at 80%";
        }
    }

    class HeavyTruck : Vehicle
    {
        public HeavyTruck(string name):base(name)
        {
            ModelName = name;
        }
        public override void Move()
        {
            Console.WriteLine($"{ModelName} is hauling cargo with high-torque diesel power.");
        }
        //BASE CLASS GetFuelStatus()
    }

    class CargoPlane : Vehicle
    {
        public CargoPlane(string name):base(name)
        {
            ModelName = name;
        }
        public override void Move()
        {
            Console.WriteLine($"{ModelName} is ascending to 30,000 feet.");
        }
        public override string GetFuelStatus()
        {
            return base.GetFuelStatus()+"Checking jet fuel reserves...";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Vehicle[] vehicle =
            {
                new ElectricCar("Tesla ModelX"),
                new HeavyTruck("Volvo HyperLoop"),
                new CargoPlane("Boeing 747")
            };
            foreach(Vehicle v1 in vehicle)
            {
                v1.Move();
                Console.WriteLine(v1.GetFuelStatus());
                    
            }
        }
    }
}
