using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Database.Models.Economics.CryptoWallets
{
    [SuppressMessage("ReSharper", "AutoPropertyCanBeMadeGetOnly.Local")]
    public class CryptoWallet : AbstractAccount
    {
        // ReSharper disable once UnusedMember.Global
        protected CryptoWallet()
        {
        }

        public CryptoWallet(double startSum) => Sum = startSum;

        public List<CryptoTransaction> Transactions { get; } = new List<CryptoTransaction>();
    }
}