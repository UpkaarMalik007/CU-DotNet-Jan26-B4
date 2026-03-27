using AccountService.DTOs;

namespace AccountService.Services
{
    public interface IAccountServices
    {
        AccountDto Create(CreateAccountDto dto);
        List<AccountDto> GetAll();
        AccountDto GetById(int id);
        void Deposit(TransactionDto dto);
        void Withdraw(TransactionDto dto);
    }
}
