using System;
using Database.Models;
using Database.Models.AccountEvents;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Account>(account =>
            {
                account.HasKey(a => a.SocialClubId);
                account.HasMany(a => a.Characters).WithOne(c => c.Account);
                account.HasMany(a => a.Connections).WithOne();
            });
        }
    }
}