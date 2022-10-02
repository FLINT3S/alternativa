using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Database.Models.Economics.Cash
{
    [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Local")]
    [SuppressMessage("ReSharper", "AutoPropertyCanBeMadeGetOnly.Local")]
    public class CashTransaction : AbstractModel
    {
        protected CashTransaction()
        {
        }

        public CashTransaction(double sum, Character from, Character to)
        {
            Sum = sum;
            From = from;
            To = to;
        }

        public Guid Id { get; private set; }

        public double Sum { get; private set; }

        public Character From { get; private set; }
        
        public Character To { get; private set; }
    }
}