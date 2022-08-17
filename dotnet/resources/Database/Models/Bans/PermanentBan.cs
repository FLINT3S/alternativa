namespace Database.Models.Bans
{
    public class PermanentBan : AbstractBan
    {
        protected PermanentBan()
        {
        }

        public PermanentBan(string hwid, Account givenBy, BanReason reason = BanReason.Other, string? description = null) :
            base(givenBy, reason, description) => HWID = hwid;

        public string HWID { get; private set; }
    }
}