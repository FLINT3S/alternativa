using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Database.Models.Economics.Banks;
using Database.Models.Economics.CryptoWallets;
using GTANetworkAPI;

namespace Database.Models
{
    [SuppressMessage("ReSharper", "AutoPropertyCanBeMadeGetOnly.Local")]
    public partial class Character : AbstractModel, IBankClient
    {
        // ReSharper disable once UnusedMember.Global
        protected Character()
        {
        }

        public Character(Account account, string firstname, string lastname, DateTime birthday)
        {
            Account = account;
            FirstName = firstname;
            LastName = lastname;
            Birthday = birthday;
            InGameTime = TimeSpan.Zero;
        }

        public Vector3 LastPosition { get; private set; }

        private TimeSpan TimeToReborn { get; set; } = TimeSpan.Zero;

        #region Finances

        public long Cash { get; set; }

        public List<BankAccount> BankAccounts { get; } = new List<BankAccount>();

        public List<CryptoWallet> CryptoWallets { get; } = new List<CryptoWallet>();

        #endregion

        #region Main Data

        public Guid Id { get; }

        public Account Account { get; }

        public TimeSpan InGameTime { get; private set; } = TimeSpan.Zero;

        #endregion

        #region Biography

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public DateTime Birthday { get; private set; }

        #endregion
    }
}