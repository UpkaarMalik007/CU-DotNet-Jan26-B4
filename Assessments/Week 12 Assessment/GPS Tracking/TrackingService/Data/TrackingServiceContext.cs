using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TrackingService.Models;

namespace TrackingService.Data
{
    public class TrackingServiceContext : DbContext
    {
        public TrackingServiceContext (DbContextOptions<TrackingServiceContext> options)
            : base(options)
        {
        }

        public DbSet<TrackingService.Models.GpsTracking> GpsTrackings { get; set; } = default!;
    }
}
