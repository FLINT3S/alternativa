using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Database.Models;
using Database.Models.AccountEvents;
using Database.Models.Bans;
using Database.Models.Economics.Banks;
using Database.Models.Economics.CryptoWallets;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Configuration;

namespace Database
{
    [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Local")]
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public partial class AltContext : DbContext
    {
        private static readonly IConfigurationRoot Config;

        static AltContext() => Config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();
        
        #region Account

        public DbSet<Account> Accounts { get; private set; }

        public DbSet<AccountEvent> AccountEvents { get; private set; }
        
        public DbSet<AbstractBan> Bans { get; private set; }
        
        public DbSet<Character> Characters { get; private set; }

        #endregion

        #region Economics

        public DbSet<BankAccount> BankAccounts { get; private set; }
        
        public DbSet<BankTransaction> BankTransactions { get; private set; }
        
        public DbSet<CryptoWallet> CryptoWallets { get; private set; }
        
        public DbSet<CryptoTransaction> CryptoTransactions { get; private set; }

        #endregion

        private static string ConnectionString => Config.GetConnectionString("AltDatabase");

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseNpgsql(ConnectionString);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new AccountConfiguration());
            modelBuilder.ApplyConfiguration(new CharacterConfigurations());

            modelBuilder.ApplyConfiguration<AccountEvent>(new EventConfigurations());
            modelBuilder.ApplyConfiguration<ConnectionEvent>(new EventConfigurations());

            #region Bans
            
            modelBuilder.ApplyConfiguration<AbstractBan>(new BanConfigurations());
            modelBuilder.ApplyConfiguration<TemporaryBan>(new BanConfigurations());
            modelBuilder.ApplyConfiguration<PermanentBan>(new BanConfigurations());

            #endregion

            #region Economics

            modelBuilder.ApplyConfiguration(new BankConfiguration());
            modelBuilder.ApplyConfiguration(new BankAccountConfiguration());
            modelBuilder.ApplyConfiguration(new CryptoWalletConfiguration());
            
            #endregion
        }

        public override int SaveChanges()
        {
            IQueryable<EntityEntry<AbstractModel>> entries = ChangeTracker.Entries<AbstractModel>().AsQueryable();
            IQueryable<EntityEntry<AbstractModel>> models = entries.Where(entityEntry => entityEntry.Entity != null);
            IQueryable<EntityEntry<AbstractModel>> editedModels = models.Where(
                    e => e.State == EntityState.Added || e.State == EntityState.Modified
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