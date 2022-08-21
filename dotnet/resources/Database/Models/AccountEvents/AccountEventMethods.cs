using System.Threading.Tasks;

namespace Database.Models.AccountEvents
{
    public partial class AccountEvent
    {
        public override async Task AddToContext()
        {
            var context = AlternativaContext.Instance;
            await context.AccountEvents.AddAsync(this);
            await context.SaveChangesAsync();
        }
    }
}