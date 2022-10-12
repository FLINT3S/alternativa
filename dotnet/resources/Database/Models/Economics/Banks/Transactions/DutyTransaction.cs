namespace Database.Models.Economics.Banks.Transactions
{
    public class DutyTransaction : AbstractBankTransaction
    {
        protected DutyTransaction()
        {
        }

        public DutyTransaction(double amount, BankAccount from) : base(amount, from)
        {
        }
    }
}