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

        protected AbstractBankTransaction(double sum, BankAccount from)
        {
            Sum = sum;
            From = from;
        }
        
        public Guid Id { get; protected set; }

        public BankAccount From { get; protected set; }
    }
}