using System;

namespace Database.Models.Bans
{
    public class TemporaryBan : AbstractBan
    {
        public TemporaryBan(DateTime endTime, Account givenBy, BanReason reason = BanReason.Other,
            string? description = null) : base(
                givenBy,
                reason,
                description
            ) => EndTime = endTime;

        public DateTime EndTime { get; }
    }
}