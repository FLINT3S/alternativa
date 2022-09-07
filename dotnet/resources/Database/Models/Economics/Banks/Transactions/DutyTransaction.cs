namespace Database.Models.Economics.Banks.Transactions
{
    public class DutyTransaction : AbstractBankTransaction
    {
        protected DutyTransaction()
        {
        }

        public DutyTransaction(double sum, BankAccount from) : base(sum, from)
        {
        }
    }
}