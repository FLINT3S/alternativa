using Database.Models;
using Database.Models.AccountEvents;
using Database.ModelsConfiguration;
using Microsoft.EntityFrameworkCore;

namespace Database
{
    public class AlternativaContext : DbContext
    {
        private string _connectionString = DatabaseConfig.ConnectionString;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_connectionString);
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<ConnectionEvent> ConnectionEvents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new AccountConfiguration());
            modelBuilder.ApplyConfiguration(new CharacterConfigurations());
            modelBuilder.ApplyConfiguration(new ConnectionEventConfiguration());
            
        }
    }
}