namespace Database.Models.AccountEvents
{
    public partial class AccountEvent
    {
        public override void AddToContext()
        {
            lock (AlternativaContext.Instance)
            {
                var context = AlternativaContext.Instance;
                context.AccountEvents.Add(this);
                context.SaveChanges();
            }
        }
    }
}