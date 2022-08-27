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
            var context = AltContext.Instance;
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
            var context = AltContext.Instance;
            context.Update(this);
            Console.WriteLine($"Updating {this}");
            context.SaveChanges();
        }
    }
}