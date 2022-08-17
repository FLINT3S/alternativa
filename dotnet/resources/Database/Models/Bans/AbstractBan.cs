using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database.Models.Bans
{
    public abstract class AbstractBan : AbstractModel
    {
        // EF Core .ctor
        protected AbstractBan()
        {
        }

        protected AbstractBan(Account givenBy, BanReason reason, string? description)
        {
            GivenBy = givenBy;
            Reason = reason;
            Description = description;
        }

        public Guid Id { get; private set; }

        public BanReason Reason { get; private set;}

        public string? Description { get; private set; }

        public Account GivenBy { get; private set; }

        [NotMapped] public DateTime StartDate => CreatedDate;
    }
}