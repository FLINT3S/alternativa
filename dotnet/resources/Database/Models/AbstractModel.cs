using System;
using Microsoft.EntityFrameworkCore;

namespace Database.Models
{
    public abstract class AbstractModel
    {
        public DateTime CreatedDate { get; internal set; } = DateTime.Now;

        public DateTime UpdatedDate { get; internal set; } = DateTime.Now;
        
        public virtual void AddToContext()
        {
            lock (AlternativaContext.Instance)
            {
                var context = AlternativaContext.Instance;
                context.Add(this);
                context.SaveChanges();
            }
        }
        
        private protected void UpdateDatabase()
        {
            try
            {
                UpdateInContext();
            }
            catch (DbUpdateException)
            {
                AddToContext();
            }
        }

        private void UpdateInContext()
        {
            lock (AlternativaContext.Instance)
            {
                var context = AlternativaContext.Instance;
                context.Update(this);
                context.SaveChanges();
            }
        }
    }
}