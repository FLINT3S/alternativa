using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Database.Models.Economics.CryptoWallets
{
    [SuppressMessage("ReSharper", "AutoPropertyCanBeMadeGetOnly.Local")]
    public class CryptoWallet : AbstractAccount
    {
        public List<CryptoTransaction> Transactions { get; } = new List<CryptoTransaction>();

        protected CryptoWallet()
        {
        }
        
        public CryptoWallet(double startSum)
        {
            Sum = startSum;
        }
    }
}