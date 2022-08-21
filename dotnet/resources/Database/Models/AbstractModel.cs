using System;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Database.Models
{
    public abstract class AbstractModel
    {
        public DateTime CreatedDate { get; internal set; } = DateTime.Now;

        public DateTime UpdatedDate { get; internal set; } = DateTime.Now;
        
        public virtual async Task AddToContext()
        {
            var context = AlternativaContext.Instance;
            await context.AddAsync(this);
            await context.SaveChangesAsync();
        }
        
        private protected async Task UpdateDatabase()
        {
            try
            {
                var context = AlternativaContext.Instance;
                context.Update(this);
                await context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                await AddToContext();
            }
        }
    }
}