using System.Collections;

namespace Day24Part02_SortedDictionary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<double, string> leadboard = new SortedDictionary<double, string>();
            leadboard.Add(55.42, "SwiftRacer");
            leadboard.Add(52.10, "SpeedDemon");
            leadboard.Add(58.91, "SteadyEddie");
            leadboard.Add(51.05, "TurboTom");

            foreach (var item in leadboard)
            {
                Console.WriteLine($"Player: {item.Value} LapTime:{item.Key}");
            }

            //Gold Medal Time
            Console.WriteLine($"Gold Medal Time: {leadboard.Keys.First()}");
            

            double  oldkey = 0;
            bool found = false;
            string name = "SteadyEddie";
            foreach(var item in leadboard)
            {
                if (item.Value == name)
                {
                    oldkey = item.Key;
                    found = true;
                    break;
                }
            }
            double newKey = 54.00d;
            if (found)
            {
                leadboard.Remove(oldkey);
                leadboard.Add(newKey, name);
            }

            foreach(var item in leadboard)
            {
                Console.WriteLine($"Name: {item.Value} LapTime:{item.Key}");
            }



        }
    }
}
