using System.Diagnostics.CodeAnalysis;

namespace Database.Models.Economics.CryptoWallets
{
    [SuppressMessage("ReSharper", "AutoPropertyCanBeMadeGetOnly.Global")]
    public class CryptoTransaction : AbstractTransaction
    {
        // ReSharper disable once UnusedMember.Global
        protected CryptoTransaction()
        {
        }

        public CryptoTransaction(double amount, CryptoWallet from, CryptoWallet to)
        {
            Amount = amount;
            From = from;
            To = to;
        }

        public CryptoWallet From { get; protected set; }

        public CryptoWallet To { get; protected set; }
    }
}