using Database.Models.Economics.Banks.Transactions;

namespace Database.Models.Economics.Banks
{
    public partial class BankAccount
    {
        public void Recalculate()
        {
            Sum += Sum * Rate / 100;
            Transactions.Add(new DutyTransaction(Sum * Rate, this));
            UpdateInContext();
        }
    }
}