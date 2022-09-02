using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Database.Models.Economics.Banks
{
    [SuppressMessage("ReSharper", "AutoPropertyCanBeMadeGetOnly.Global")]
    public class BankAccount : AbstractAccount
    {
        protected BankAccount()
        {
        }
        
        public BankAccount(IBankClient client, Bank bank)
        {
            Bank = bank;
            Owner = client;
        } 
        
        public IBankClient Owner { get; protected set; }
        
        public Bank Bank { get; protected set; }

        public List<BankTransaction> Transactions { get; } = new List<BankTransaction>();
    }
}