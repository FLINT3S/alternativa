using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Database.Models.Economics.Banks
{
    [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
    public class Bank : AbstractModel
    {
        protected Bank()
        {
        }
        
        public long Id { get; protected set; }
        
        public double Money { get; protected set; }

        public List<BankAccount> Accounts { get; } = new List<BankAccount>();
    }
}