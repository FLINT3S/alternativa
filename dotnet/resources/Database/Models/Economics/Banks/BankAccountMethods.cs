namespace Database.Models.Economics.Banks
{
    public partial class BankAccount
    {
        public void Recalculate()
        {
            Sum += Sum * Rate / 100;
            Transactions.Add(new BankTransaction(Sum * Rate / 100, this, null));
            UpdateInContext();
        }
    }
}