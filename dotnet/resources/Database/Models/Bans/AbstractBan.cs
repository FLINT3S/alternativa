using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database.Models.Bans
{
    public class AbstractBan : AbstractModel
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

        public Guid Id { get; }

        public BanReason Reason { get; }

        public string? Description { get; }

        public Account GivenBy { get; }

        [NotMapped] public DateTime StartDate => CreatedDate;
    }
}