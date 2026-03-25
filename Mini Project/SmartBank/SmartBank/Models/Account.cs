using Microsoft.EntityFrameworkCore;

namespace SmartBank.Models
{
    public class Account
    {
        public int Id { get; set; }
        public string AccountNumber { get; set; }
        public string Name { get; set; }
        [Precision(18,4)]
        public decimal Balance { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
