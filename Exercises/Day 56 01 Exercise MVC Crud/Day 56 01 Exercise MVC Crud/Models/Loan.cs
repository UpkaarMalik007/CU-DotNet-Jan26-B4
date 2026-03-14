using System.ComponentModel.DataAnnotations;

namespace Day_56_01_Exercise_MVC_Crud.Models
{
    public class Loan
    {
        public int Id { get; set; }

        [Display(Name = "Borrower Name")]
        public string BorrowerName { get; set; }
        public string LenderName { get; set; }

        [Range(1, 500000)]
        public double Amount { get; set; }
        public bool IsSettled { get; set; }
    }
}
