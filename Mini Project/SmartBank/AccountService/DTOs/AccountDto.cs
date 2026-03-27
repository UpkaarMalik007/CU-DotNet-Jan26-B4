using System.ComponentModel.DataAnnotations;

namespace AccountService.DTOs
{
    public class AccountDto
    {
        public int Id { get; set; }
        [Required]
        public string AccountNumber { get; set; }
        [Required]
        public string Name { get; set; }
        public decimal Balance { get; set; }
    }
}
