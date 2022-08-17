using System;

namespace Database.Models
{
    public abstract class AbstractModel
    {
        public DateTime CreatedDate { get; internal set; }

        public DateTime UpdatedDate { get; internal set; }

        private protected void UpdateDatabase()
        {
            using var context = new AlternativaContext();
            context.Update(this);
            context.SaveChanges();
        }
    }
}