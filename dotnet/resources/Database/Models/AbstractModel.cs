using System;
using Microsoft.EntityFrameworkCore;

namespace Database.Models
{
    public abstract class AbstractModel
    {
        public DateTime CreatedDate { get; internal set; } = DateTime.Now;

        public DateTime UpdatedDate { get; internal set; } = DateTime.Now;
        
        public void AddToContext()
        {
            using var context = new AltContext();
            context.Add(this);
            context.SaveChanges();
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

        public void UpdateInContext()
        {
            using var context = new AltContext();
            context.Update(this);
            context.SaveChanges();
        }
    }
}