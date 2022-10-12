using System;
using System.Diagnostics.CodeAnalysis;

namespace Database.Models.Bans
{
    [SuppressMessage("ReSharper", "AutoPropertyCanBeMadeGetOnly.Local")]
    public class PermanentBan : AbstractBan
    {
        // ReSharper disable once UnusedMember.Global
        protected PermanentBan()
        {
        }

        public PermanentBan(string hwid, Account givenBy, Account givenTo, BanReason reason = BanReason.Other,
            string description = null) :
            base(givenBy, givenTo, reason, description)
        {
            AccountId = givenTo.Id;
            HWID = hwid;
        }

        public PermanentBan(Account givenBy, Account givenTo, BanReason reason = BanReason.Other, string description = null) :
            this(givenTo.LastHwid, givenBy, givenTo, reason, description)
        {
        }

        private Guid AccountId { get; set; }

        public string HWID { get; private set; }
    }
}