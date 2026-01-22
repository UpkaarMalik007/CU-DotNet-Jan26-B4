using System.ComponentModel;

namespace Day15Exercise
{
    class Height
    {
        public int Feet { get; set; }

        public double Inches { get; set; }

        public Height()
        {
            Feet = 0;
            Inches = 0.0;
        }

        public Height(int feet,double inches)
        {
            Feet = feet;
            Inches = inches;
        }

        public Height(double totalInches)     
        {
            Feet = (int)(totalInches / 12);
            Inches = totalInches % 12;
        }

        public Height AddHeight(Height h2)
        {
            int hFeet = this.Feet + h2.Feet;
            double hInches = this.Inches + h2.Inches;

            if (hInches >= 12)
            {
                hFeet += (int)(hInches / 12);
                hInches = hInches % 12;
            }

            return new Height(hFeet, hInches);
        }

        public override string ToString()
        {
            return $"Height - {Feet} feet {Inches:F1} inches";
        }

        

    }
    internal class HeightCLASS
    {
        static void Main(string[] args)
        {
            //Height person1 = new Height(5,6.5);
            //Height person2 = new Height(5, 7.5);

            Height person1 = new Height(13.5);
            Height person2 = new Height(5, 6.5);

            Height total = person1.AddHeight(person2);

            Console.WriteLine(person1);
            Console.WriteLine(person2);
            Console.WriteLine(total);

            
        }
    }
}
