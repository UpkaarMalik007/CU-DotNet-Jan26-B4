using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day31LINQExercise
{
    internal class _05CustomerOrder
    {
        class Customer 
        { 
            public int Id; 
            public string Name; 
            public string City; 
        }
        class Order 
        { 
            public int OrderId; 
            public int CustomerId; 
            public double Amount; 
        }

        static void Main(string[] args)
        {
            var customers = new List<Customer>
            {
                new Customer{Id=1, Name="Ajay", City="Delhi"},
                new Customer{Id=2, Name="Sunita", City="Mumbai"}
            };

            var orders = new List<Order>
            {
                new Order{OrderId=1, CustomerId=1, Amount=20000},
                new Order{OrderId=2, CustomerId=1, Amount=40000}
            };

            var firstJoin = customers.Join(orders, c => c.Id, o => o.OrderId, (c, o) => new
            {
                Name = c.Name,
                amount = o.Amount
            });

            Console.WriteLine("---------------");
            Console.WriteLine("---------------");
            Console.WriteLine("order AMount Per Customer");
            foreach (var i in firstJoin)
            {
                Console.WriteLine(i.Name + " - " + i.amount);
            }
            Console.WriteLine("---------------");
            Console.WriteLine("Customers With No order");
            var zeroOrder = firstJoin.Where(x => x.amount == 0);
            foreach (var i in zeroOrder)
            {
                Console.WriteLine(zeroOrder);
            }
            Console.WriteLine("---------------");
            Console.WriteLine("Customers Spent Above 50000");
            var aboveFifty = firstJoin.Where(x => x.amount > 50000);
            foreach (var i in aboveFifty)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("---------------");
            Console.WriteLine("Sort Customer By Spendings");
            var custSort = firstJoin.OrderByDescending(x => x.amount);
            foreach (var i in custSort)
            {
                Console.WriteLine(i.Name + " - " + i.amount);
            }


        }
    }
}
