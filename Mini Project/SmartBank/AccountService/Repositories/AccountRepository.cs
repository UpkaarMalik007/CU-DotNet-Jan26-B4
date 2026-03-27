
using AccountService.Data;
using AccountService.Models;

namespace AccountService.Repositories
{
    public class AccountRepository:IAccountRepository
    {
        private readonly AccountServiceContext _context;

        public AccountRepository(AccountServiceContext context)
        {
            _context = context;
        }

        public Account Create(Account account)
        {
            _context.Account.Add(account);
            _context.SaveChanges();
            return account;
        }

        public List<Account> GetAll()
        {
            return _context.Account.ToList();
        }

        public Account? GetById(int id)
        {
            return _context.Account.Find(id);
        }

        public void Update(Account account)
        {
            _context.Account.Update(account);
            _context.SaveChanges();
        }
    }
}
