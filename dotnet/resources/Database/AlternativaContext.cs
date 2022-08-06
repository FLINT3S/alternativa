using System;
using Database.Models;
using GTANetworkAPI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Player = GTANetworkAPI.Player;

namespace Database
{
    public class AlternativaContext : DbContext
    {
        private string _connectionString = new DatabaseConfig().ConnectionString;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            NAPI.Util.ConsoleOutput(_connectionString);
            optionsBuilder.UseNpgsql(_connectionString);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserEvent> UserEvents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserEvent>()
                .HasOne<User>(ue => ue.User);
            modelBuilder.Entity<UserEvent>()
                .ToTable("UserEvents");
            modelBuilder.Entity<UserEvent>()
                .Property(ue => ue.DateTime)
                .HasDefaultValue(DateTime.Now);
        }
    }
}