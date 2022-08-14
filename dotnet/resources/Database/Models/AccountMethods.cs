using System;
using Database.Models.AccountEvents;
using Logger;
using Logger.EventModels;

namespace Database.Models
{
    public partial class Account
    {
        // todo придумать систему логов действий с аккаунтом
        
        private string ip = null!, hwid = null!;
        
        public void UpdateUsername(string newUsername)
        {
            Username = newUsername != Username ? newUsername : throw new InvalidOperationException("Usernames are same!");
            AltLogger.Instance.LogInfo(new AltAccountEvent(SocialClubId, this, "UsernameUpdate", "Username changed"));
        }
        
        public void UpdatePassword(string newPassword)
        {
            Password = newPassword != Password ? newPassword : throw new InvalidOperationException("Usernames are same!");
            AltLogger.Instance.LogInfo(new AltAccountEvent(SocialClubId, this, "PasswordUpdate", "Password changed"));
        }
        
        public void UpdateEmail(string newEmail)
        {
            Email = newEmail != Email ? newEmail : throw new InvalidOperationException("Usernames are same!");
            AltLogger.Instance.LogInfo(new AltAccountEvent(SocialClubId, this, "EmailUpdate", "Email changed"));
        }

        public void OnConnect(string ip, string hwid)
        {
            this.ip = ip;
            this.hwid = hwid;
            Connections.Add(new ConnectionEvent(ConnectionEventType.Connected, ip, hwid, $"Account connected."));
            AltLogger.Instance.LogInfo(new AltAccountEvent(SocialClubId, this, "Connect", $"Account connected. HWID: {hwid}, IP: {ip}"));
        }

        public void OnDisconnect()
        {
            Connections.Add(new ConnectionEvent(ConnectionEventType.Disconnected, ip, hwid, $"Account disconnected"));
            AltLogger.Instance.LogInfo(new AltAccountEvent(SocialClubId, this, "Disonnect", $"Account disconnected."));
        }
    }
}