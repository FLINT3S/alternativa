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

        public CryptoTransaction(double sum, CryptoWallet from, CryptoWallet to)
        {
            Sum = sum;
            From = from;
            To = to;
        }

        public CryptoWallet From { get; protected set; }

        public CryptoWallet To { get; protected set; }
    }
}