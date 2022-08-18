namespace Database.Models.Bans
{
    public class PermanentBan : AbstractBan
    {
        protected PermanentBan()
        {
        }

        public PermanentBan(string hwid, Account givenBy, Account givenTo, BanReason reason = BanReason.Other, string? description = null) :
            base(givenBy, givenTo, reason, description)
        {
            AccountId = givenTo.SocialClubId;
            HWID = hwid;
        }

        private ulong AccountId { get; set; }
        
        public string HWID { get; private set; }
    }
}