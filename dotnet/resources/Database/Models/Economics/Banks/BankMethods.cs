using System.Collections.Generic;
using System.Linq;

namespace Database.Models.Economics.Banks
{
    public partial class Bank
    {
        public static IEnumerable<BankAccount> GetAccounts()
        {
            using var context = new AltContext();
            return context.BankAccounts.ToList();
        }
    }
}