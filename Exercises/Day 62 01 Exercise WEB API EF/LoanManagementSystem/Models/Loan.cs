using Microsoft.EntityFrameworkCore;

namespace LoanManagementSystem.Models
{
    public class Loan
    {
        public int Id { get; set; }
        public string BorrowerName { get; set; }
        [Precision(18,4)]
        public decimal Amount { get; set; }
        public int LoanTermMonths { get; set; }
        public bool IsApproved { get; set; }
    }
}
