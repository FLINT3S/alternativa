using System;
using Database.Models.AccountEvents;
using Logger;
using Logger.EventModels;

namespace Database.Models
{
    public partial class Account
    {
        private string ip = null!, hwid = null!;
        
        public void UpdateUsername(string newUsername)
        {
            Username = newUsername != Username ? newUsername : throw new InvalidOperationException("Usernames are same!");
            AltLogger.Instance.LogInfo(new AltAccountEvent(this, "UsernameUpdate", "Username changed"));
        }
        
        public void UpdatePassword(string newPassword)
        {
            Password = newPassword != Password ? newPassword : throw new InvalidOperationException("Usernames are same!");
            AltLogger.Instance.LogInfo(new AltAccountEvent(this, "PasswordUpdate", "Password changed"));
        }
        
        public void UpdateEmail(string newEmail)
        {
            Email = newEmail != Email ? newEmail : throw new InvalidOperationException("Usernames are same!");
            AltLogger.Instance.LogInfo(new AltAccountEvent(this, "EmailUpdate", "Email changed"));
        }

        public void OnConnect(string ip, string hwid)
        {
            this.ip = ip;
            this.hwid = hwid;
            Connections.Add(new ConnectionEvent(ConnectionEventType.Connected, ip, hwid, $"Account connected."));
            AltLogger.Instance.LogInfo(new AltAccountEvent(this, "Connect", $"Account connected. HWID: {hwid}, IP: {ip}"));
        }

        public void OnDisconnect()
        {
            Connections.Add(new ConnectionEvent(ConnectionEventType.Disconnected, ip, hwid, $"Account disconnected"));
            AltLogger.Instance.LogInfo(new AltAccountEvent(this, "Disonnect", $"Account disconnected."));
        }

        public override string ToString()
        {
            return $"{Username}_[{SocialClubId}]";
        }
    }
}