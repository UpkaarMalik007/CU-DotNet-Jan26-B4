using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day31LINQExercise
{
    internal class _07BankTransaction
    {
        class Transaction 
        { 
            public int Acc; 
            public double Amount; 
            public string Type; 
        }
        static void Main(string[] args)
        {
            var transactions = new List<Transaction>
            {
                new Transaction{Acc=101, Amount=5000, Type="Credit"},
                new Transaction{Acc=101, Amount=2000, Type="Debit"},
                new Transaction{Acc=102, Amount=10000, Type="Debit"}
            };

            Console.WriteLine("---------------");
            Console.WriteLine("---------------");
            Console.WriteLine("total Balance per Account");
            var totalBalance = transactions.GroupBy(x => x.Acc).Select(y => new
            {
                acc = y.Key,
                balance = y.Sum(z => z.Amount)
            });

            foreach (var i in totalBalance)
            {
                Console.WriteLine(i.acc + " - " + i.balance);
            }
            Console.WriteLine("---------------");
            Console.WriteLine("Suspecious Account");
            var susAcc = transactions.GroupBy(x => x.Acc).Select(y => new
            {
                group = y.Key,
                debit = y.Where(z => z.Type == "Debit").Sum(s => s.Amount),
                credit = y.Where(z => z.Type == "Credit").Sum(s => s.Amount),

            }).Where(a => a.debit > a.credit);

            foreach (var i in susAcc)
            {
                Console.WriteLine($"{i.group} Debit: {i.debit} Credit: {i.credit}");
            }
            Console.WriteLine("---------------");
            Console.WriteLine("highest Transaction per Acc");
            var highestTrans = transactions.GroupBy(y => y.Acc).Select(x => x.OrderByDescending(z => z.Amount).First());
            foreach (var i in highestTrans)
            {
                Console.WriteLine(i.Acc + " - " + i.Amount);
            }


        }
    }
}
