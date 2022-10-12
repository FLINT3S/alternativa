using System;
using System.Diagnostics.CodeAnalysis;

namespace Database.Models.Economics.Banks.Transactions
{
    [SuppressMessage("ReSharper", "AutoPropertyCanBeMadeGetOnly.Global")]
    public abstract class AbstractBankTransaction : AbstractTransaction
    {
        // ReSharper disable once UnusedMember.Global
        protected AbstractBankTransaction()
        {
        }

        protected AbstractBankTransaction(double amount, BankAccount from)
        {
            Amount = amount;
            From = from;
        }

        public BankAccount From { get; protected set; }
    }
}