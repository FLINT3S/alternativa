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
            AccountId = givenTo.SocialClubId;
            HWID = hwid;
        }

        private ulong AccountId { get; set; }

        public string HWID { get; private set; }
    }
}