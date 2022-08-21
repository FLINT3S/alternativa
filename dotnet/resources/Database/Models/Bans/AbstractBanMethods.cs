namespace Database.Models.Bans
{
    public partial class AbstractBan
    {
        public override void AddToContext()
        {
            lock (AlternativaContext.Instance)
            {
                var context = AlternativaContext.Instance;
                context.Bans.Add(this);
                context.SaveChanges();
            }
        }
    }
}