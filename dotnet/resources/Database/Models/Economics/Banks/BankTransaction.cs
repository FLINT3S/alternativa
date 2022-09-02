using System.Diagnostics.CodeAnalysis;

namespace Database.Models.Economics.Banks
{
    [SuppressMessage("ReSharper", "AutoPropertyCanBeMadeGetOnly.Global")]
    public class BankTransaction : AbstractTransaction
    {
        // ReSharper disable once UnusedMember.Global
        protected BankTransaction()
        {
        }

        public BankTransaction(double sum, BankAccount from, BankAccount to)
        {
            Sum = sum;
            From = from;
            To = to;
        }

        public BankAccount From { get; protected set; }

        public BankAccount To { get; protected set; }
    }
}