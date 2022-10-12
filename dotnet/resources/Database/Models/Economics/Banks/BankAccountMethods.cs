using System.ComponentModel.DataAnnotations.Schema;
using Database.Models.Economics.Banks.Transactions;

namespace Database.Models.Economics.Banks
{
    public partial class BankAccount
    {
        [NotMapped] public Character Owner => OwnerFinances.Owner;
        
        public void Recalculate()
        {
            Amount += Amount * Rate / 100;
            Transactions.Add(new DutyTransaction(Amount * Rate, this));
            PushToContext();
        }
    }
}