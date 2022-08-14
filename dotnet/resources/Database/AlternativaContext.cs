using System;
using Database.Models;
using Database.Models.AccountEvents;
using Database.ModelsConfigiration;
using GTANetworkAPI;
using Microsoft.EntityFrameworkCore;

namespace Database
{
    public class AlternativaContext : DbContext
    {
        private string _connectionString = DatabaseConfig.ConnectionString;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            NAPI.Util.ConsoleOutput(_connectionString);
            optionsBuilder.UseNpgsql(_connectionString);
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<ConnectionEvent> ConnectionEvents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new AccountConfiguration());
            modelBuilder.Entity<ConnectionEvent>(connectionEvent =>
            {
                connectionEvent.HasKey(e => e.Id);
            });
            modelBuilder.Entity<Character>(character =>
            {
                character.HasKey(c => c.Id);
            });
        }
    }
}