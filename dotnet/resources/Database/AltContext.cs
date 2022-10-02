using System.Diagnostics.CodeAnalysis;
using Database.Models;
using Database.Models.AccountEvents;
using Database.Models.Bans;
using Database.Models.Economics.Banks;
using Database.Models.Economics.Banks.Transactions;
using Database.Models.Economics.Cash;
using Database.Models.Economics.CryptoWallets;
using Database.Models.Rooms;
using Microsoft.EntityFrameworkCore;

namespace Database
{
    [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Local")]
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public partial class AltContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Account
            
            modelBuilder.ApplyConfiguration(new AccountConfiguration());

            modelBuilder.ApplyConfiguration<AccountEvent>(new EventConfigurations());
            modelBuilder.ApplyConfiguration<ConnectionEvent>(new EventConfigurations());

            modelBuilder.ApplyConfiguration<AbstractBan>(new BanConfigurations());
            modelBuilder.ApplyConfiguration<TemporaryBan>(new BanConfigurations());
            modelBuilder.ApplyConfiguration<PermanentBan>(new BanConfigurations());

            #endregion

            #region Character

            modelBuilder.ApplyConfiguration(new CharacterConfigurations());
            modelBuilder.ApplyConfiguration(new CharacterAppearanceConfiguration());
            modelBuilder.ApplyConfiguration(new CharacterFinancesConfiguration());
            modelBuilder.ApplyConfiguration(new CharacterSpawnDataConfiguration());

            #endregion
            
            #region Economics

            modelBuilder.ApplyConfiguration(new BankConfiguration());
            modelBuilder.ApplyConfiguration(new BankAccountConfiguration());
            modelBuilder.ApplyConfiguration(new CashTransactionConfiguration());
            modelBuilder.ApplyConfiguration<AbstractBankTransaction>(new TransactionConfiguration());
            modelBuilder.ApplyConfiguration<BetweenCharactersTransaction>(new TransactionConfiguration());
            modelBuilder.ApplyConfiguration<DutyTransaction>(new TransactionConfiguration());
            modelBuilder.ApplyConfiguration<PurchaseTransaction>(new TransactionConfiguration());
            
            modelBuilder.ApplyConfiguration(new CryptoWalletConfiguration());

            #endregion

            #region Real Estate

            modelBuilder.ApplyConfiguration<AbstractRoom>(new RealEstateConfiguration());
            modelBuilder.ApplyConfiguration<AbstractRealEstate>(new RealEstateConfiguration());
            modelBuilder.ApplyConfiguration<House>(new RealEstateConfiguration());
            modelBuilder.ApplyConfiguration<Garage>(new RealEstateConfiguration());
            modelBuilder.ApplyConfiguration(new ColShapeConfiguration());
            modelBuilder.ApplyConfiguration(new RoomColShapeConfiguration());

            #endregion
        }

        #region Account

        public DbSet<Account> Accounts { get; private set; }

        public DbSet<AccountEvent> AccountEvents { get; private set; }

        public DbSet<AbstractBan> Bans { get; private set; }

        public DbSet<Character> Characters { get; private set; }

        #endregion

        #region Economics

        public DbSet<CashTransaction> CashTransactions { get; private set; }

        public DbSet<BankAccount> BankAccounts { get; private set; }

        public DbSet<AbstractBankTransaction> BankTransactions { get; private set; }

        public DbSet<CryptoWallet> CryptoWallets { get; private set; }

        public DbSet<CryptoTransaction> CryptoTransactions { get; private set; }

        #endregion

        #region Real Estate
        
        public DbSet<ColShape> ColShapes { get; private set; }
        
        public DbSet<RoomColShape> RoomColShapes { get; private set; }
        
        public DbSet<AbstractRoom> Rooms { get; private set; }

        public DbSet<House> Houses { get; private set; }
        
        public DbSet<Garage> Garages { get; private set; }

        #endregion
    }
}