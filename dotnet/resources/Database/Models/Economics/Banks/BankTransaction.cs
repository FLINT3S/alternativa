using System.Diagnostics.CodeAnalysis;

namespace Database.Models.Economics.Banks
{
    [SuppressMessage("ReSharper", "AutoPropertyCanBeMadeGetOnly.Global")]
    public class BankTransaction : AbstractTransaction
    {
        public BankAccount From { get; protected set; }
        
        public BankAccount To { get; protected set; }

        protected BankTransaction()
        {
        }

        public BankTransaction(double sum, BankAccount from, BankAccount to)
        {
            Sum = sum;
            From = from;
            To = to;
        }
    }
}