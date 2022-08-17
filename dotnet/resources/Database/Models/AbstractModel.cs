using System;
using Microsoft.EntityFrameworkCore;

namespace Database.Models
{
    public abstract class AbstractModel
    {
        public DateTime CreatedDate { get; internal set; } = DateTime.Now;

        public DateTime UpdatedDate { get; internal set; } = DateTime.Now;

        private protected void UpdateDatabase()
        {
            using var context = new AlternativaContext();
            try
            {
                context.Update(this);
                context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                context.Add(this);
                context.SaveChanges();
            }
        }
    }
}