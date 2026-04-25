using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TicketBookingSystem.TripService.Models;

namespace TicketBookingSystem.TripService.Data
{
    public class TripDbContext : DbContext
    {
        public TripDbContext (DbContextOptions<TripDbContext> options)
            : base(options) {}

        public DbSet<TicketBookingSystem.TripService.Models.Trip> Trip { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Trip>(entity =>
            {
                entity.HasKey(t => t.Id);

                entity.Property(t => t.Heading)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(t => t.ShipName)
                    .HasMaxLength(100);

                entity.Property(t => t.TripType)
                    .HasMaxLength(50);

                // ✅ SQL Server does NOT support array → store as string
                entity.Property(t => t.Ports)
                    .HasConversion(
                        v => string.Join(',', v),
                        v => v.Split(',', StringSplitOptions.RemoveEmptyEntries)
                    );

                entity.Property(t => t.Price)
                    .HasColumnType("decimal(10,2)");

                entity.Property(t => t.StartDate)
                    .HasColumnType("datetime2");

                entity.Property(t => t.EndDate)
                    .HasColumnType("datetime2");
            });
        }
    }
}
