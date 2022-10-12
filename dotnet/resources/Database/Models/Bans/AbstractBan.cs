using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Database.Models.Bans
{
    [SuppressMessage("ReSharper", "AutoPropertyCanBeMadeGetOnly.Local")]
    public abstract class AbstractBan : AbstractModel
    {
        // EF Core .ctor
        protected AbstractBan()
        {
        }

        protected AbstractBan(Account givenBy, Account givenTo, BanReason reason, string description)
        {
            GivenBy = givenBy;
            GivenTo = givenTo;
            Reason = reason;
            Description = description;
        }

        public BanReason Reason { get; private set; }

        public string Description { get; private set; }

        public Account GivenTo { get; private set; }

        public Account GivenBy { get; private set; }

        [NotMapped] public DateTime StartDate => CreatedDate;
    }
}