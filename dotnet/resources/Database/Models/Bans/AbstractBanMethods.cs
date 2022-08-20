namespace Database.Models.Bans
{
    public partial class AbstractBan
    {
        public override void AddToContext()
        {
            using var context = new AlternativaContext();
            context.Bans.Add(this);
            context.SaveChanges();
        }
    }
}