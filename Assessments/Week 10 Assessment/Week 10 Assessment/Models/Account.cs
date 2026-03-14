namespace Week_10_Assessment.Models
{
    public class Account
    {
        public int Id { get; set; }
        public string AccountNumber { get; set; }

        public string AccountName { get; set; }
        public double Balance { get; set; }
        public List<Transaction> Transactions { get; set; } = new List<Transaction>();
    }
}
