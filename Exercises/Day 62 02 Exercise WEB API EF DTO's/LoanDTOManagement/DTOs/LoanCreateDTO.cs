using System.ComponentModel.DataAnnotations;

namespace LoanDTOManagement.DTOs
{
    public class LoanCreateDTO
    {
        [Required]
        public string BorrowerName { get; set; }

        [Required]
        [Range(1, double.MaxValue)]
        public decimal Amount { get; set; }

        [Required]
        [Range(1, 600)]
        public int LoanTermMonths { get; set; }

        public bool IsApproved { get; set; } = false;
    }
}
