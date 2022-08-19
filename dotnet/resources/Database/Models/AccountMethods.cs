using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Database.Models.AccountEvents;
using Database.Models.Bans;
using Logger;
using Logger.EventModels;

namespace Database.Models
{
    public partial class Account
    {
        private string ip = null!, hwid = null!;
        
        #region Simple user data

        public void UpdateUsername(string newUsername)
        {
            Username = newUsername != Username ? newUsername : throw new InvalidOperationException("Usernames are same!");
            UpdateDatabase();
            AltLogger.Instance.LogInfo(new AltAccountEvent(this, "UsernameUpdate", "Username changed"));
        }

        public void UpdateEmail(string newEmail)
        {
            Email = newEmail != Email ? newEmail : throw new InvalidOperationException("Usernames are same!");
            UpdateDatabase();
            AltLogger.Instance.LogInfo(new AltAccountEvent(this, "EmailUpdate", "Email changed"));
        }

        #endregion

        #region Passwords

        public bool IsPasswordsMatch(string incomingPassword) =>
            GetPasswordHash(incomingPassword) == PasswordHash;

        public void UpdatePassword(string newPassword)
        {
            if (IsPasswordsMatch(newPassword))
                throw new InvalidOperationException("Usernames are same!");

            SetNewPasswordData(newPassword);
            UpdateDatabase();
            AltLogger.Instance.LogInfo(new AltAccountEvent(this, "PasswordUpdate", "Password changed"));
        }

        private string GetPasswordHash(string password) =>
            GetSha256(password + PasswordSalt);

        private static string GetSha256(string data)
        {
            using var sha256Hash = SHA256.Create();
            byte[] sourceBytes = Encoding.UTF8.GetBytes(data);
            byte[] hashBytes = sha256Hash.ComputeHash(sourceBytes);
            return BitConverter.ToString(hashBytes).Replace("-", string.Empty);
        }

        private void SetNewPasswordData(string newPassword)
        {
            PasswordSalt = GetSha256(GetRandomString());
            ;
            PasswordHash = GetPasswordHash(newPassword);
        }

        private static string GetRandomString()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            string response = string.Empty;
            for (int i = 0; i < 128; i++)
                response += chars[RandomNumberGenerator.GetInt32(chars.Length)];
            return response;
        }

        #endregion
        
        #region HWID

        public bool IsSameHwid(string hwid) => LastHwid == hwid;

        public void UpdateHwid(string newHwid)
        {
            LastHwid = newHwid;
            UpdateDatabase();
        }

        #endregion

        #region Bans

        public bool IsTemporaryBanned() => GetLongestBan().EndDate - DateTime.Now > TimeSpan.Zero;

        public TemporaryBan GetLongestBan() => TemporaryBans
            .FirstOrDefault(b => b.EndDate == TemporaryBans.Max(ban => ban.EndDate));

        public void Ban(AbstractBan ban)
        {
            ban.AddToContext();
            switch (ban)
            {
                case PermanentBan permanentBan:
                {
                    PermanentBan = permanentBan;
                    break;
                }
                case TemporaryBan temporaryBan:
                {
                    TemporaryBans.Add(temporaryBan);
                    break;
                }
                default:
                    throw new ArgumentOutOfRangeException(nameof(ban));
            }
            UpdateDatabase();
        }

        #endregion

        #region On Events

        public void OnConnect(string ip, string hwid)
        {
            this.ip = ip;
            this.hwid = hwid;

            var ce = new ConnectionEvent(ConnectionEventType.Connected, ip, hwid, "Account connected.");
            ce.AddToContext();
            Connections.Add(ce);
            UpdateDatabase();
            AltLogger.Instance.LogInfo(new AltAccountEvent(this, "Connect", $"Account connected. HWID: {hwid}, IP: {ip}"));
        }

        public void OnCharacterPeek(Character? peekedCharacter)
        {
            ActiveCharacter = peekedCharacter;
            UpdateDatabase();
        }

        public void OnDisconnect()
        {
            ActiveCharacter = null;
            UpdateDatabase();
            Connections.Add(new ConnectionEvent(ConnectionEventType.Disconnected, ip, hwid, "Account disconnected"));
            AltLogger.Instance.LogInfo(new AltAccountEvent(this, "Disconnect", "Account disconnected."));
        }

        #endregion

        public override bool Equals(object obj) => ToString().Equals(obj?.ToString() ?? "null");

        public override int GetHashCode() => ToString().GetHashCode();

        public override string ToString() => $"{Username}_[{SocialClubId}]";
    }
}