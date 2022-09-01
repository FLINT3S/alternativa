using System.Collections.Generic;

namespace Database.Models.Economics.Banks
{
    public class Bank : AbstractModel
    {
        protected Bank()
        {
        }
        
        public long Id { get; private set; }
        
        public double Money { get; private set; }

        public List<BankAccount> Accounts { get; } = new List<BankAccount>();
    }
}