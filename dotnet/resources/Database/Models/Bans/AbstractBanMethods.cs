using System.Threading.Tasks;

namespace Database.Models.Bans
{
    public partial class AbstractBan
    {
        public override async Task AddToContext()
        {
            var context = AlternativaContext.Instance;
            await context.Bans.AddAsync(this);
            await context.SaveChangesAsync();
        }
    }
}