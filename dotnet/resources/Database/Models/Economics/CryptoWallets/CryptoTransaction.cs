namespace Database.Models.Economics.CryptoWallets
{
    public class CryptoTransaction : AbstractTransaction
    {
        public CryptoWallet From { get; set; }
        
        public CryptoWallet To { get; set; }
    }
}