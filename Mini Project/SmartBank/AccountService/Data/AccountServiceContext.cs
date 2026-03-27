using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AccountService.Models;

namespace AccountService.Data
{
    public class AccountServiceContext : DbContext
    {
        public AccountServiceContext (DbContextOptions<AccountServiceContext> options)
            : base(options)
        {
        }

        public DbSet<AccountService.Models.Account> Account { get; set; } = default!;
    }
}
