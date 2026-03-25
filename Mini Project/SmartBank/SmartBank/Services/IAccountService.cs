using SmartBank.DTOs;

namespace SmartBank.Services
{
    public interface IAccountService
    {
        AccountDto Create(CreateAccountDto dto);
        List<AccountDto> GetAll();
        AccountDto GetById(int id);
        void Deposit(TransactionDto dto);
        void Withdraw(TransactionDto dto);
    }
}
