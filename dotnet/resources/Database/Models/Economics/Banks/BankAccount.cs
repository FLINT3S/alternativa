namespace Database.Models.Economics.Banks
{
    public class BankAccount : AbstractModel
    {
        protected BankAccount()
        {
        }
        
        public BankAccount(Bank bank)
        {
            Bank = bank;
        }
        
        public long Id { get; set; }     
        
        public Bank Bank { get; private set; }
    }
}