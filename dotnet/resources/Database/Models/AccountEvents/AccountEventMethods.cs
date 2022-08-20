namespace Database.Models.AccountEvents
{
    public partial class AccountEvent
    {
        public override void AddToContext()
        {
            using var context = new AlternativaContext();
            context.AccountEvents.Add(this);
            context.SaveChanges();
        }
    }
}