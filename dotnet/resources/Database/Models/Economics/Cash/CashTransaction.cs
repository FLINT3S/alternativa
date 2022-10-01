using System;
using System.Diagnostics.CodeAnalysis;

namespace Database.Models.Economics.Cash
{
    [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Local")]
    public class CashTransaction : AbstractModel
    {
        protected CashTransaction() {}

        public Guid Id { get; private set; }
        
        public Character From { get; private set; }
        
        public Character To { get; private set; }
    }
}