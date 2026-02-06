using System;
using System.Collections.Generic;
using System.IO;

namespace Day25Part2CSV
{
    class Player
    {
        public string Name { get; set; }
        public int RunsScored { get; set; }
        public int BallsFaced { get; set; }
        public bool IsOut { get; set; }
        public double StrikeRate { get; set; }
        public double Average { get; set; }

        public Player(string n, int run, int b, bool o)
        {
            Name = n;
            RunsScored = run;
            BallsFaced = b;
            IsOut = o;

            // Strike Rate (no ternary)
            if (BallsFaced == 0)
                StrikeRate = 0;
            else
                StrikeRate = (double)RunsScored * 100 / BallsFaced;

            // Average (single innings)
            Average = RunsScored;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string[] data =
                {
                    "Steve Smith,84,90,True",
                    "Virat Kohli,29,35,false",
                    "Joe Root,110,120,True"
                };

                string fileName = @"..\..\..\players.csv";

                File.WriteAllLines(fileName, data);

                string[] lines = File.ReadAllLines(fileName);

                List<Player> players = new List<Player>();

                // Dynamic CSV parsing
                foreach (string line in lines)
                {
                    string[] s = line.Split(',');

                    Player p = new Player(
                        s[0],
                        int.Parse(s[1]),
                        int.Parse(s[2]),
                        bool.Parse(s[3])
                    );

                    players.Add(p);
                }

                for (int i = players.Count - 1; i >= 0; i--)
                {
                    if (players[i].BallsFaced < 10)
                    {
                        players.RemoveAt(i);
                    }
                }

                var v = players.OrderByDescending(x => x.StrikeRate).ToList();

                Console.WriteLine("Name            Runs      SR      Avg");
                

                foreach (Player p in players)
                {
                    Console.WriteLine($"{p.Name,-15}{p.RunsScored,-8}{p.StrikeRate,8:F2}{p.Average,8:F2}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
