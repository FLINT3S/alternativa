using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Database.Models.Economics.Banks
{
    [SuppressMessage("ReSharper", "AutoPropertyCanBeMadeGetOnly.Global")]
    public partial class BankAccount : AbstractAccount
    {
        // ReSharper disable once UnusedMember.Global
        protected BankAccount()
        {
        }

        public BankAccount(IBankClient client, Bank bank, BankAccountType type, double rate)
        {
            Bank = bank;
            Type = type;
            Rate = rate;
            Owner = client;
        }

        public double Rate { get; protected set; }

        public BankAccountType Type { get; protected set; }

        public IBankClient Owner { get; protected set; }

        public Bank Bank { get; protected set; }

        public List<BankTransaction> Transactions { get; } = new List<BankTransaction>();
    }
}