namespace Database.Models.AccountEvents
{
    public partial class AccountEvent
    {
        public void AddToContext()
        {
            using var context = new AlternativaContext();
            context.AccountEvents.Add(this);
            context.SaveChanges();
        }
    }
}