using System.ComponentModel.DataAnnotations.Schema;
using Database.Models.Economics.Banks.Transactions;

namespace Database.Models.Economics.Banks
{
    public partial class BankAccount
    {
        [NotMapped] public Character Owner => OwnerFinances.Owner;
        
        public void Recalculate()
        {
            Sum += Sum * Rate / 100;
            Transactions.Add(new DutyTransaction(Sum * Rate, this));
            PushInContext();
        }
    }
}