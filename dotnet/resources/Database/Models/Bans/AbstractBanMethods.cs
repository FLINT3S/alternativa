namespace Database.Models.Bans
{
    public partial class AbstractBan
    {
        public override void AddToContext()
        {
            lock (ContextSingleton.Instance)
            {
                var context = ContextSingleton.Instance;
                context.Bans.Add(this);
                context.SaveChanges();
            }
        }
    }
}