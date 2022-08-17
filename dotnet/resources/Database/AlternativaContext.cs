using System;
using System.Collections.Generic;
using System.Linq;
using Database.Models;
using Database.Models.AccountEvents;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Database
{
    public class AlternativaContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(DatabaseConfig.ConnectionString);
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
        
        public override int SaveChanges()
        {
            IEnumerable<EntityEntry> entries = ChangeTracker.Entries()
                .Where(
                    e => e.Entity is AbstractModel && 
                         (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                ((AbstractModel)entityEntry.Entity).UpdatedDate = DateTime.Now;

                if (entityEntry.State == EntityState.Added)
                    ((AbstractModel)entityEntry.Entity).CreatedDate = DateTime.Now;
            }

            return base.SaveChanges();
        }
    }
}