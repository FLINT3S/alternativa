using System;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using Database.Models.AccountEvents;
using Logger;
using Logger.EventModels;

namespace Database.Models
{
    public partial class Account
    {
        private string ip = null!, hwid = null!;

        public bool IsPasswordsMatch(string incomingPassword)
        {
            return GetSha256(incomingPassword + PasswordSalt) == PasswordHash;
        }

        #region Update user data

        public void UpdateUsername(string newUsername)
        {
            Username = newUsername != Username ? newUsername : throw new InvalidOperationException("Usernames are same!");
            AltLogger.Instance.LogInfo(new AltAccountEvent(this, "UsernameUpdate", "Username changed"));
        }
        
        public void UpdatePassword(string newPassword)
        {
            if (IsPasswordsMatch(newPassword))
                throw new InvalidOperationException("Usernames are same!");

            string newSalt = GetSha256(DateTime.Now.ToString(CultureInfo.CurrentCulture));
            using (var context = new AlternativaContext())
            {
                PasswordSalt = newSalt;
                PasswordHash = GetSha256(newPassword + newSalt);
                context.Update(this);
                context.SaveChanges();
            }
            
            AltLogger.Instance.LogInfo(new AltAccountEvent(this, "PasswordUpdate", "Password changed"));
        }

        private static string GetSha256(string data)
        {
            using var sha256Hash = SHA256.Create();
            byte[] sourceBytes = Encoding.UTF8.GetBytes(data);
            byte[] hashBytes = sha256Hash.ComputeHash(sourceBytes);
            string hash = BitConverter.ToString(hashBytes).Replace("-", string.Empty);
            return hash;
        } 
        
        public void UpdateEmail(string newEmail)
        {
            Email = newEmail != Email ? newEmail : throw new InvalidOperationException("Usernames are same!");
            AltLogger.Instance.LogInfo(new AltAccountEvent(this, "EmailUpdate", "Email changed"));
        }

        #endregion

        #region On Events

        public void OnConnect(string ip, string hwid)
        {
            this.ip = ip;
            this.hwid = hwid;
            Connections.Add(new ConnectionEvent(ConnectionEventType.Connected, ip, hwid, $"Account connected."));
            AltLogger.Instance.LogInfo(new AltAccountEvent(this, "Connect", $"Account connected. HWID: {hwid}, IP: {ip}"));
        }

        public void OnCharacterPeek(Character peekedCharacter)
        {
            using var context = new AlternativaContext();
            ActiveCharacter = peekedCharacter;
            context.Update(this);
            context.SaveChanges();
        }

        public void OnDisconnect()
        {
            using (var context = new AlternativaContext())
            {
                ActiveCharacter = null;
                context.Update(this);
                context.SaveChanges();
            }
            Connections.Add(new ConnectionEvent(ConnectionEventType.Disconnected, ip, hwid, $"Account disconnected"));
            AltLogger.Instance.LogInfo(new AltAccountEvent(this, "Disconnect", $"Account disconnected."));
        }

        #endregion

        public override string ToString() => $"{Username}_[{SocialClubId}]";
    }
}