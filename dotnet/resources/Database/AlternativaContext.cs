using System;
using Database.Models;
using Microsoft.EntityFrameworkCore;
using Player = GTANetworkAPI.Player;

namespace Database
{
    public class AlternativaContext : DbContext
    {
        private string _connectionString = "Host=127.0.0.1;Port=5432;Database=alt;Uid=postgres;Password=1804;";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
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