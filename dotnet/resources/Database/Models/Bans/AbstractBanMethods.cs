namespace Database.Models.Bans
{
    public partial class AbstractBan
    {
        public void AddToContext()
        {
            using var context = new AlternativaContext();
            context.Bans.Add(this);
            context.SaveChanges();
        }
    }
}