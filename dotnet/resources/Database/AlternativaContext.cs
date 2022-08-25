using System;
using Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Database
{
    public class AlternativaContext : DbContext
    {
        private static readonly IConfigurationRoot Config;
        
        private static string ConnectionString => Config.GetConnectionString("AltDatabase");

        static AlternativaContext()
        {
            Config = new ConfigurationBuilder()
                .AddJsonFile(GetSettingsFilename())
                .Build();
        }

        private static string GetSettingsFilename()
        {
            #if DEBUG
                return "appsettings.Development.json";
            #else
                return "appsettings.Release.json";
            #endif
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => 
            optionsBuilder.UseNpgsql(ConnectionString);

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