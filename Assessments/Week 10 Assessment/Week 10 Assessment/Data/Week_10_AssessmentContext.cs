using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Week_10_Assessment.Models;

namespace Week_10_Assessment.Data
{
    public class Week_10_AssessmentContext : DbContext
    {
        public Week_10_AssessmentContext (DbContextOptions<Week_10_AssessmentContext> options)
            : base(options)
        {
        }

        public DbSet<Account> Accounts { get; set; }

        public DbSet<Transaction> Transactions { get; set; }
    }
}
