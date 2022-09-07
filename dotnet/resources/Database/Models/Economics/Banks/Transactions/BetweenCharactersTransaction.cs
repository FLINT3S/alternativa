using System.Diagnostics.CodeAnalysis;

namespace Database.Models.Economics.Banks.Transactions
{
    [SuppressMessage("ReSharper", "AutoPropertyCanBeMadeGetOnly.Global")]
    public class BetweenCharactersTransaction : AbstractBankTransaction
    {
        public BankAccount To { get; protected set; }
        
        protected BetweenCharactersTransaction()
        {
        }

        public BetweenCharactersTransaction(double sum, BankAccount from, BankAccount to) : base(sum, from)
        {
            To = to;
        }
    }
}