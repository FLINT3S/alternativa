using System.Diagnostics.CodeAnalysis;

namespace Database.Models.Economics
{
    [SuppressMessage("ReSharper", "AutoPropertyCanBeMadeGetOnly.Local")]
    public class CryptoWallet : AbstractModel
    {
        protected CryptoWallet()
        {
        }
        
        public CryptoWallet(double startMoney)
        {
            Money = startMoney;
        }
        
        public double Money { get; private set; }
        
        public long Id { get; set; }
    }
}