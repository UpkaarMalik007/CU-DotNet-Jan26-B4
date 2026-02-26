namespace Day_30_01_ExpenseShare
{
    internal class FairShare
    {
        static List<string> SettleExpenseShare(Dictionary<string, decimal> expenses)
        {
            List<string> settlement = new List<string>();

            Queue<KeyValuePair<string, decimal>> receivers =
                new Queue<KeyValuePair<string, decimal>>();

            Queue<KeyValuePair<string, decimal>> payers =
                new Queue<KeyValuePair<string, decimal>>();

            decimal totalExpense = expenses.Values.Sum();
            int persons = expenses.Count;
            decimal share = totalExpense / persons;

            foreach (var person in expenses)
            {
                if (person.Value > share)
                {
                    receivers.Enqueue(
                        new KeyValuePair<string, decimal>(
                            person.Key,
                            Math.Round(person.Value - share, 2)
                        ));
                }
                else if (person.Value < share)
                {
                    payers.Enqueue(
                        new KeyValuePair<string, decimal>(
                            person.Key,
                            Math.Round(share - person.Value, 2)
                        ));
                }
            }

            while (payers.Count > 0 && receivers.Count > 0)
            {
                var payer = payers.Dequeue();
                var receiver = receivers.Dequeue();

                decimal amount = Math.Min(payer.Value, receiver.Value);
                amount = Math.Round(amount, 2);

                settlement.Add(
                    $"{payer.Key},{receiver.Key},{amount:F2}"
                );

                if (payer.Value > amount)
                {
                    payers.Enqueue(
                        new KeyValuePair<string, decimal>(
                            payer.Key,
                            Math.Round(payer.Value - amount, 2)
                        ));
                }

                if (receiver.Value > amount)
                {
                    receivers.Enqueue(
                        new KeyValuePair<string, decimal>(
                            receiver.Key,
                            Math.Round(receiver.Value - amount, 2)
                        ));
                }
            }

            return settlement;
        }

        static void Main(string[] args)
        {
            Dictionary<string, decimal> expenses =
                new Dictionary<string, decimal>()
            {
                {"Aman",900 },
                {"Sunil",700 },
                {"Kartik",2000 }
            };

            List<string> settlement = SettleExpenseShare(expenses);

            Console.WriteLine("Payer,Receiver,Amount");

            foreach (var item in settlement)
            {
                Console.WriteLine(item);
            }
        }
    }
}
