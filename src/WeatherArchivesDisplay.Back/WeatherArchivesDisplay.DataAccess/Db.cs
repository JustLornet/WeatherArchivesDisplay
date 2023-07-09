using Microsoft.EntityFrameworkCore;
using WeatherArchivesDisplay.Domain.Aggreagtes;

namespace WeatherArchivesDisplay.DataAccess
{
    public sealed class Db : DbContext
    {
        public Db(DbContextOptions<Db> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<LogEntry> LogEntries => Set<LogEntry>();
        public DbSet<DataSource> DataSources => Set<DataSource>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<LogEntry>(new LogEntry());
            modelBuilder.ApplyConfiguration<DataSource>(new DataSource());
        }
    }
}