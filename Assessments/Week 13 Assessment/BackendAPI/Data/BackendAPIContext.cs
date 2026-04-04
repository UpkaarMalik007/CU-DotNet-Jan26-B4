using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BackendAPI.Model;

namespace BackendAPI.Data
{
    public class BackendAPIContext : DbContext
    {
        public BackendAPIContext (DbContextOptions<BackendAPIContext> options)
            : base(options)
        {
        }

        public DbSet<BackendAPI.Model.Destination> Destination { get; set; } = default!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Destination>(entity =>
            {
                entity.Property(x => x.CityName).IsRequired();

                entity.Property(x => x.Country).IsRequired();
                entity.Property(x => x.Description).HasMaxLength(200);

                entity.Property(x => x.Rating).HasDefaultValue(3);
            });
        }
    }
}
