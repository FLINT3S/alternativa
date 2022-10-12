using System;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace Database.Models
{
    [SuppressMessage("ReSharper", "AutoPropertyCanBeMadeGetOnly.Local")]
    public abstract class AbstractModel
    {
        [JsonProperty("guid")] public Guid Id { get; }
        
        public DateTime CreatedDate { get; internal set; } = DateTime.Now;

        public DateTime UpdatedDate { get; internal set; } = DateTime.Now;

        public void PushToContext()
        {
            using var context = new AltContext();
            context.Update(this);
            context.SaveChanges();
        }

        protected void PullFromContext()
        {
            using var context = new AltContext();
            context.Attach(this);
            context.Entry(this).Reload();
        }
    }
}