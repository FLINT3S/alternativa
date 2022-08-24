namespace Database.Models.AccountEvents
{
    public partial class AccountEvent
    {
        public override void AddToContext()
        {
            lock (AltDb.Context)
            {
                var context = AltDb.Context;
                context.AccountEvents.Add(this);
                context.SaveChanges();
            }
        }
    }
}