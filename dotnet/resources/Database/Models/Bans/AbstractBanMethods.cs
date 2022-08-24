namespace Database.Models.Bans
{
    public partial class AbstractBan
    {
        public override void AddToContext()
        {
            lock (AltDb.Context)
            {
                var context = AltDb.Context;
                context.Bans.Add(this);
                context.SaveChanges();
            }
        }
    }
}