﻿using System.Diagnostics.CodeAnalysis;
using Database.Models;
using Database.Models.AccountEvents;
using Database.Models.Bans;
using Database.Models.Economics.Banks;
using Database.Models.Economics.Banks.Transactions;
using Database.Models.Economics.CryptoWallets;
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

        #region Account

        public DbSet<Account> Accounts { get; private set; }

        public DbSet<AccountEvent> AccountEvents { get; private set; }

        public DbSet<AbstractBan> Bans { get; private set; }

        public DbSet<Character> Characters { get; private set; }

        #endregion

        #region Economics

        public DbSet<BankAccount> BankAccounts { get; private set; }

        public DbSet<AbstractBankTransaction> BankTransactions { get; private set; }

        public DbSet<CryptoWallet> CryptoWallets { get; private set; }

        public DbSet<CryptoTransaction> CryptoTransactions { get; private set; }

        #endregion
    }
}