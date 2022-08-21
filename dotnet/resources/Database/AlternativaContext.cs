using System;
using System.Linq;
using Database.Models;
using Database.Models.AccountEvents;
using Database.Models.Bans;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Database
{
    public class AlternativaContext : DbContext
    {
        public static AlternativaContext Instance { get; } = new AlternativaContext();

        private AlternativaContext()
        {
        }
        
        public DbSet<Account> Accounts { get; private set; }

        public DbSet<Character> Characters { get; set; }

        public DbSet<AccountEvent> AccountEvents { get; set; }

        public DbSet<AbstractBan> Bans { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => 
            optionsBuilder.UseNpgsql(DatabaseConfig.ConnectionString);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new AccountConfiguration());
            modelBuilder.ApplyConfiguration(new CharacterConfigurations());
            
            modelBuilder.ApplyConfiguration<AccountEvent>(new EventConfigurations());
            modelBuilder.ApplyConfiguration<ConnectionEvent>(new EventConfigurations());
            
            modelBuilder.ApplyConfiguration<AbstractBan>(new BanConfigurations());
            modelBuilder.ApplyConfiguration<TemporaryBan>(new BanConfigurations());
            modelBuilder.ApplyConfiguration<PermanentBan>(new BanConfigurations());
        }

        public override int SaveChanges()
        {
            IQueryable<EntityEntry<AbstractModel>> entries = ChangeTracker.Entries<AbstractModel>().AsQueryable();
            IQueryable<EntityEntry<AbstractModel>> models = entries.Where(entityEntry => entityEntry.Entity != null);
            IQueryable<EntityEntry<AbstractModel>> editedModels = models.Where(
                    e =>
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