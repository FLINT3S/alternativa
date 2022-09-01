using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Database.Models.AccountEvents;
using Database.Models.Bans;

namespace Database.Models
{
    [SuppressMessage("ReSharper", "AutoPropertyCanBeMadeGetOnly.Local")]
    public partial class Account : AbstractModel
    {
        // ReSharper disable once UnusedMember.Global
        protected Account()
        {
        }

        public Account(ulong socialClubId, string username, string password, string email)
        {
            SocialClubId = socialClubId;
            Username = username;
            Email = email;
            SetNewPasswordData(password);
        }

        public ulong SocialClubId { get; private set; }

        public string Username { get; private set; }

        private string PasswordHash { get; set; } = null!;

        private string PasswordSalt { get; set; } = null!;

        private string Email { get; set; }

        private string LastHwid { get; set; } = null!;

        public List<TemporaryBan> TemporaryBans { get; } = new List<TemporaryBan>();

        public PermanentBan PermanentBan { get; private set; }

        public List<Character> Characters { get; } = new List<Character>();

        public List<ConnectionEvent> Connections { get; } = new List<ConnectionEvent>();
    }
}