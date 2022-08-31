using System;

namespace Database.Models.Bans
{
    public partial class TemporaryBan : AbstractBan
    {
        protected TemporaryBan()
        {
        }

        public TemporaryBan(TimeSpan duration, Account givenBy, Account givenTo, BanReason reason = BanReason.Other,
            string description = null) : base(givenBy, givenTo, reason, description) => Duration = duration;

        public TimeSpan Duration { get; private set; }
    }
}