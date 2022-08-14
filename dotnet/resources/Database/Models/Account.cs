using System.Collections.Generic;
using Database.Models.AccountEvents;

namespace Database.Models
{
    public partial class Account
    {
        private Account()
        {
        }

        public Account(ulong socialClubId, string username, string password, string email)
        {
            SocialClubId = socialClubId;
            Username = username;
            Password = password;
            Email = email;
        }
        
        public ulong SocialClubId { get; }
        
        public string Username { get; private set; }

        public string Password { get; private set; }
        
        public string Email { get; private set; }
        
        public string LastHwid { get; set; }

        public List<Character> Characters { get; } = new List<Character>();

        public List<ConnectionEvent> Connections { get; } = new List<ConnectionEvent>();
    }
}