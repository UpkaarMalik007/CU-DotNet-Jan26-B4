namespace Day_47_01_Cargo_Exercise
{
    class Item
    {
        public string Name { get; set; }
        public double Weight { get; set; }
        public string Category { get; set; }
        public Item(string name, double weight, string category)
        {
            Name = name;
            Weight = weight;
            Category = category;
        }
    }
    class Container
    {
        public string ContainerId { get; set; }
        public List<Item> Items { get; set; }

        public Container(string id, List<Item> items)
        {
            ContainerId = id;
            Items = items;
        }

        public static List<string> FindHeavyContainers(List<List<Container>> containers, double weightThreshold)
        {
            List<string> result = new List<string>();
            return contianers
                .SelectMany(c => c)
                .Where(c => c.Items.Sum(i => i.Weight) > weightThreshold)
                .Select(c => c.ContainerId).ToList();

            foreach (var row in containers)
            {
                foreach (var container in row)
                {
                    double totalWeight = 0;

                    foreach (var item in container.Items)
                    {
                        totalWeight += item.Weight;
                    }

                    if (totalWeight > weightThreshold)
                    {
                        result.Add(container.ContainerId);
                    }
                }

            }
            return result;
        }

        public static Dictionary<string,int> GetItemCountsByCategory(List<List<Container>> containers)
        {
            return containers.
                SelectMany(r => r).
                SelectMany(c => c.Items).
                GroupBy(item => item.Category).
                ToDictionary(
                group => group.Key,
                group => group.Count());
        }

        public static List<Item> FlattenAndSortShipment(List<List<Container>> containers)
        {
            return containers
                .SelectMany(r => r)
                .SelectMany(c => c.Items)
                .GroupBy(g => g.Name)
                .Select(g => g.First())
                .OrderBy(g => g.Category)
                .ThenByDescending(g => g.Weight)
                .ToList();
        }

    }


    internal class Program
    {
        static void Main(string[] args)
        {
            var cargoBay = new List<List<Container>>
            {
                // ROW 0: High-Value Tech Row
                new List<Container>
                {
                    new Container("C001", new List<Item>
                    {
                        new Item("Laptop", 2.5, "Tech"),
                        new Item("Monitor", 5.0, "Tech"),
                        new Item("Smartphone", 0.5, "Tech")
                    }),
                    new Container("C104", new List<Item>
                    {
                        new Item("Server Rack", 45.0, "Tech"), // Heavy Item
                        new Item("Cables", 1.2, "Tech")
                    })
                },

                // ROW 1: Mixed Consumer Goods
                new List<Container>
                {
                    new Container("C002", new List<Item>
                    {
                        new Item("Apple", 0.2, "Food"),
                        new Item("Banana", 0.2, "Food"),
                        new Item("Milk", 1.0, "Food")
                    }),
                    new Container("C003", new List<Item>
                    {
                        new Item("Table", 15.0, "Furniture"),
                        new Item("Chair", 7.5, "Furniture")
                    })
                },

                // ROW 2: Fragile & Perishables (Includes an Empty Container)
                new List<Container>
                {
                    new Container("C205", new List<Item>
                    {
                        new Item("Vase", 3.0, "Decor"),
                        new Item("Mirror", 12.0, "Decor")
                    }),
                    new Container("C206", new List<Item>()) // EDGE CASE: Container with no items
                },

                // ROW 3: EDGE CASE - Empty Row
                new List<Container>() // A row that exists but has no containers
            };

            var heavy = Container.FindHeavyContainers(cargoBay, 20);
            foreach (var id in heavy)
            {
                Console.WriteLine(id);
            }

            var categoryCounts = Container.GetItemCountsByCategory(cargoBay);

            foreach (var entry in categoryCounts)
            {
                Console.WriteLine($"{entry.Key} : {entry.Value}");
            }

            var finalShipment = Container.FlattenAndSortShipment(cargoBay);

            foreach (var item in finalShipment)
            {
                Console.WriteLine($"{item.Category} - {item.Name} - {item.Weight}");
            }

        }
    }
}
