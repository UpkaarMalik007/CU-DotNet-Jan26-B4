using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day31LINQExercise
{
    class Product 
    { 
        public int Id; 
        public string Name; 
        public string Category; 
        public double Price; 
    }
    class Sale 
    { 
        public int ProductId; 
        public int Qty; 
    }

    internal class ProductInventory
    {
        static void Main(string[] args)
        {
            var products = new List<Product>
            {
                new Product{Id=1, Name="Laptop", Category="Electronics", Price=50000},
                new Product{Id=2, Name="Phone", Category="Electronics", Price=20000},
                new Product{Id=3, Name="Table", Category="Furniture", Price=5000}
            };

            var sales = new List<Sale>
            {
                new Sale{ProductId=1, Qty=10},
                new Sale{ProductId=2, Qty=20}
            };

            var merge = products.Join(sales, p => p.Id, s => s.ProductId, (p, s) =>
                                        new { ProductName = p.Name, Quantity = s.Qty }).ToList();
            Console.WriteLine("---------------");
            Console.WriteLine("---------------");

            Console.WriteLine("Joining product and Sales");

            foreach (var item in merge)
            {
                Console.WriteLine(item.ProductName + " - " + item.Quantity);
            }

            var totalRevenue = products.Join(sales, s => s.Id, p => p.ProductId, (p, s) => new { productName = p.Name, revenue = p.Price * s.Qty });

            Console.WriteLine("---------------");
            Console.WriteLine("Total Revenue of Products");
            foreach (var i in totalRevenue)
            {
                Console.WriteLine(i.productName + " - " + i.revenue);
            }
            Console.WriteLine("---------------");
            Console.WriteLine("Best product");
            var bestProduct = totalRevenue.OrderByDescending(x => x.revenue).First();
            Console.WriteLine(bestProduct.productName + " - " + bestProduct.revenue);

            var zeroSales = products.GroupJoin(sales, p => p.Id, s => s.ProductId, (p, s) => new
            {
                productsName = p.Name,
                totalSales = s.Sum(x => x.Qty * p.Price)
            }).Where(x => x.totalSales == 0);

            Console.WriteLine("---------------");
            Console.WriteLine("Product With Zero Sales");
            foreach (var i in zeroSales)
            {
                Console.WriteLine(i.productsName);
            }



        }

    }
}
