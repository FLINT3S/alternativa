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
            var entries = ChangeTracker.Entries<AbstractModel>().AsQueryable();
            var models = entries.Where(entityEntry => entityEntry.Entity != null);
            var editedModels = models.Where(e => 
                    e.State == EntityState.Added || e.State == EntityState.Modified
                );
            
            foreach (EntityEntry<AbstractModel> entityEntry in editedModels)
            {
                entityEntry.Entity.UpdatedDate = DateTime.Now;

                if (entityEntry.State == EntityState.Added)
                    entityEntry.Entity.CreatedDate = DateTime.Now;
            }

            return base.SaveChanges();
        }
    }
}