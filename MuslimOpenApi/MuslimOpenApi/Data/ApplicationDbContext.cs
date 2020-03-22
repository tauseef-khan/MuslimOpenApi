using Microsoft.EntityFrameworkCore;
using MuslimOpenApi.Models;

namespace MuslimOpenApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<PrayerTime> PrayerTimes { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
