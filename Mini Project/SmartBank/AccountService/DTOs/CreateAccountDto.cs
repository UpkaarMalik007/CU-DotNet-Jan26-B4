using System.ComponentModel.DataAnnotations;

namespace AccountService.DTOs
{
    public class CreateAccountDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [Range(1000, 1000000000, ErrorMessage = "Minimum balance must be ₹1000")]
        public decimal InitialDeposit { get; set; }
    }
}
