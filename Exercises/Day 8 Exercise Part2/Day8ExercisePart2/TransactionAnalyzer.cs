namespace Day8ExercisePart2
{
    internal class TransactionAnalyzer
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            // Split input
            string[] parts = input.Split('#');

            string transactionId = parts[0];
            string accountHolder = parts[1];
            string narration = parts[2];

            // ---------- NORMALIZATION ----------
            narration = narration.Trim().ToLower();

            while (narration.Contains("  "))
            {
                narration = narration.Replace("  ", " ");
            }

            // ---------- KEYWORD CHECK ----------
            bool hasDeposit = narration.Contains("deposit");
            bool hasWithdrawal = narration.Contains("withdrawal");
            bool hasTransfer = narration.Contains("transfer");

            bool hasKeyword = hasDeposit || hasWithdrawal || hasTransfer;

            // ---------- STANDARD COMPARISON ----------
            string standardNarration = "cash deposit successful";
            bool isStandard = narration.Equals(standardNarration);

            // ---------- CATEGORY ----------
            string category;

            if (!hasKeyword)
                category = "NON-FINANCIAL TRANSACTION";
            else if (hasKeyword && isStandard)
                category = "STANDARD TRANSACTION";
            else
                category = "CUSTOM TRANSACTION";

            // ---------- OUTPUT ----------
            Console.WriteLine($"Transaction ID : {transactionId}");
            Console.WriteLine($"Account Holder : {accountHolder}");
            Console.WriteLine($"Narration      : {narration}");
            Console.WriteLine($"Category       : {category}");
        }
    }
}
