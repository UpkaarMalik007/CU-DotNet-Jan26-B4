using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day31LINQExercise
{
    internal class _08ECommerceCartProcessing
    {
        class CartItem 
        { 
            public string Name; 
            public string Category; 
            public double Price; 
            public int Qty; 
        }
        static void Main(string[] args)
        {
            var cart = new List<CartItem>
            {
                new CartItem{Name="TV", Category="Electronics", Price=30000, Qty=1},
                new CartItem{Name="Sofa", Category="Furniture", Price=15000, Qty=1}
            };

            Console.WriteLine("---------------");
            Console.WriteLine("---------------");
            Console.WriteLine("Tatal Cart Value");
            var totalCartValue = cart.Sum(x => x.Price);
            Console.WriteLine(totalCartValue);

            Console.WriteLine("---------------");
            Console.WriteLine("Group By category And cost");
            var totalcostBycategory = cart.GroupBy(x => x.Category).Select(y => new
            {
                Category = y.Key,
                Amount = y.Sum(z => z.Price * z.Qty)
            });

            foreach (var i in totalcostBycategory)
            {
                Console.WriteLine(i.Category + " - " + i.Amount);
            }

            Console.WriteLine("---------------");
            Console.WriteLine("10% discount on Electronics");
            var discount = cart.Where(z => z.Category == "Electronics").Sum(x => x.Price - (x.Price * 0.10));

            Console.WriteLine(discount);

            var cartItems = cart.GroupBy(x => 1).Select(y => new
            {
                Items = y.Sum(z => z.Qty),
                Total = y.Sum(z => z.Price * z.Qty)
            });
            Console.WriteLine("---------------");
            Console.WriteLine("Dto of cart");
            foreach (var i in cartItems)
            {
                Console.WriteLine(i.Items + " - " + i.Total);
            }
        }
    }
}
