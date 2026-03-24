using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LoanDTOManagement.Models;

namespace LoanDTOManagement.Data
{
    public class LoanDTOManagementContext : DbContext
    {
        public LoanDTOManagementContext (DbContextOptions<LoanDTOManagementContext> options)
            : base(options)
        {
        }

        public DbSet<LoanDTOManagement.Models.Loan> Loan { get; set; } = default!;
    }
}
