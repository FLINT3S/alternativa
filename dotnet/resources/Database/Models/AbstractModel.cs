using System;

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

        protected void UpdateInContext()
        {
            var context = AltContext.Instance;
            context.Update(this);
            context.SaveChanges();
        }
    }
}