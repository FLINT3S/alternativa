﻿using System.Collections.Generic;
using Database.Models.AccountEvents;
using Database.Models.Bans;

namespace Database.Models
{
    public partial class Account : AbstractModel
    {
        protected Account()
        {
        }

        public Account(ulong socialClubId, string username, string password, string email)
        {
            SocialClubId = socialClubId;
            Username = username;
            Email = email;
            SetNewPasswordData(password);
            ActiveCharacter = null;
        }

        public ulong SocialClubId { get; private set; }

        public string Username { get; private set; }

        public string PasswordHash { get; private set; } = null!;

        public string PasswordSalt { get; private set; } = null!;

        public string Email { get; private set; }

        public string LastHwid { get; private set; } = null!;

        public virtual List<TemporaryBan> TemporaryBans { get; } = new List<TemporaryBan>();

        public virtual PermanentBan? PermanentBan { get; private set; } = null;

        public virtual Character? ActiveCharacter { get; set; }

        public virtual List<Character> Characters { get; } = new List<Character>();

        public virtual List<ConnectionEvent> Connections { get; } = new List<ConnectionEvent>();
    }
}