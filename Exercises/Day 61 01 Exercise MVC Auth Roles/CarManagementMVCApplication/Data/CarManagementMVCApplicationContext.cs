using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CarManagementMVCApplication.Models;

namespace CarManagementMVCApplication.Data
{
    public class CarManagementMVCApplicationContext : DbContext
    {
        public CarManagementMVCApplicationContext (DbContextOptions<CarManagementMVCApplicationContext> options)
            : base(options)
        {
        }

        public DbSet<CarManagementMVCApplication.Models.Car> Car { get; set; } = default!;
    }
}
