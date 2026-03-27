using AccountService.Models;

namespace AccountService.Repositories
{
    public interface IAccountRepository
    {
        Account Create(Account account);
        List<Account> GetAll();
        Account? GetById(int id);
        void Update(Account account);
    }
}
