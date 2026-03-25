using SmartBank.DTOs;
using SmartBank.Exceptions;
using SmartBank.Helpers;
using SmartBank.Models;
using SmartBank.Repositories;

namespace SmartBank.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _repo;

        public AccountService(IAccountRepository repo)
        {
            _repo = repo;
        }

        public AccountDto Create(CreateAccountDto dto)
        {
            if (dto.InitialDeposit < 1000)
                throw new BadRequestException("Minimum balance must be ₹1000");

            var account = new Account
            {
                Name = dto.Name,
                Balance = dto.InitialDeposit,
                AccountNumber = "Temp"
            };

            account = _repo.Create(account);

            account.AccountNumber = AccountNumberGenerator.Generate(account.Id);
            _repo.Update(account);

            
            return new AccountDto
            {
                Id = account.Id,
                AccountNumber = account.AccountNumber,
                Name = account.Name,
                Balance = account.Balance
            };
        }

        public List<AccountDto> GetAll()
        {
            var accounts = _repo.GetAll();

            
            var result = new List<AccountDto>();

            foreach (var a in accounts)
            {
                result.Add(new AccountDto
                {
                    Id = a.Id,
                    AccountNumber = a.AccountNumber,
                    Name = a.Name,
                    Balance = a.Balance
                });
            }

            return result;
        }

        public AccountDto GetById(int id)
        {
            var account = _repo.GetById(id)
                ?? throw new NotFoundException("Account not found");

            
            return new AccountDto
            {
                Id = account.Id,
                AccountNumber = account.AccountNumber,
                Name = account.Name,
                Balance = account.Balance
            };
        }

        public void Deposit(TransactionDto dto)
        {
            if (dto.Amount <= 0)
                throw new BadRequestException("Amount must be greater than zero");

            var account = _repo.GetById(dto.AccountId)
                ?? throw new NotFoundException("Account not found");

            account.Balance += dto.Amount;
            _repo.Update(account);
        }

        public void Withdraw(TransactionDto dto)
        {
            if (dto.Amount <= 0)
                throw new BadRequestException("Amount must be greater than zero");

            var account = _repo.GetById(dto.AccountId)
                ?? throw new NotFoundException("Account not found");

            if (account.Balance - dto.Amount < 1000)
                throw new BadRequestException("Minimum balance ₹1000 must be maintained");

            account.Balance -= dto.Amount;
            _repo.Update(account);
        }
    }

}
