using System;
using System.Diagnostics.CodeAnalysis;

namespace Database.Models
{
    [SuppressMessage("ReSharper", "AutoPropertyCanBeMadeGetOnly.Local")]
    public abstract class AbstractModel
    {
        public DateTime CreatedDate { get; internal set; } = DateTime.Now;

        public DateTime UpdatedDate { get; internal set; } = DateTime.Now;

        public void PushInContext()
        {
            using var context = new AltContext();
            context.Update(this);
            context.SaveChanges();
        }

        public void PullFromContext()
        {
            using var context = new AltContext();
            context.Attach(this);
            context.Entry(this).Reload();
        }
    }
}