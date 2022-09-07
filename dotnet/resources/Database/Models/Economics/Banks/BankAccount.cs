using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Database.Models.Economics.Banks.Transactions;

namespace Database.Models.Economics.Banks
{
    [SuppressMessage("ReSharper", "AutoPropertyCanBeMadeGetOnly.Global")]
    public partial class BankAccount : AbstractAccount
    {
        // ReSharper disable once UnusedMember.Global
        protected BankAccount()
        {
        }

        public BankAccount(Character client, Bank bank, BankAccountType type, double rate)
        {
            Bank = bank;
            Type = type;
            Rate = rate;
            OwnerFinances = client.Finances;
        }

        public double Rate { get; protected set; }

        public BankAccountType Type { get; protected set; }

        private CharacterFinances OwnerFinances { get; set; }

        public Bank Bank { get; protected set; }

        public List<AbstractBankTransaction> Transactions { get; } = new List<AbstractBankTransaction>();
    }
}