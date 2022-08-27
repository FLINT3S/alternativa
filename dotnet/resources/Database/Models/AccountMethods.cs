﻿using System;
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
            if (IsUsernameTaken(newUsername)) 
                throw new InvalidOperationException("This username already taken");
            Username = newUsername != Username ? 
                newUsername : throw new InvalidOperationException("Usernames are same!");
            UpdateInContext();
            AltLogger.Instance.LogInfo(new AltAccountEvent(this, "UsernameUpdate", "Username changed"));
        }

        public static bool IsUsernameTaken(string username) => 
            AltContext
                .Instance
                .Accounts
                .Select(a => new { a.Username }).Any(a => a.Username == username);

        public void UpdateEmail(string newEmail)
        {
            if (IsEmailTaken(newEmail)) 
                throw new InvalidOperationException("This email already taken");
            Email = newEmail != Email ? newEmail : throw new InvalidOperationException("Emails are same!");
            UpdateInContext();
            AltLogger.Instance.LogInfo(new AltAccountEvent(this, "EmailUpdate", "Email changed"));
        }
        
        
        private static bool IsEmailTaken(string email) => 
            AltContext.Instance.Accounts.Select(a => new { a.Email }).Any(a => a.Email == email);

        #endregion

        #region Passwords

        public bool IsPasswordsMatch(string incomingPassword) =>
            GetPasswordHash(incomingPassword) == PasswordHash;

        public void UpdatePassword(string newPassword)
        {
            if (IsPasswordsMatch(newPassword))
                throw new InvalidOperationException("Usernames are same!");

            SetNewPasswordData(newPassword);
            UpdateInContext();
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

        public bool IsSameLastHwid(string hwid) => LastHwid == hwid;

        public void UpdateHwid(string newHwid)
        {
            LastHwid = newHwid;
            UpdateInContext();
        }

        #endregion

        #region Bans

        public bool IsTemporaryBanned()
        {
            var b = GetLongestBan();
            if (b != null) return b.EndDate - DateTime.Now > TimeSpan.Zero;
            return false;
        }

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
            UpdateInContext();
        }

        #endregion

        #region Characters

        public void AddCharacter(Character character)
        {
            Characters.Add(character);
            UpdateInContext();
        }
        
        public void PeekCharacter(Character? peekedCharacter)
        {
            ActiveCharacter = peekedCharacter;
            UpdateInContext();
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
            UpdateInContext();
            AltLogger.Instance.LogInfo(new AltAccountEvent(this, "Connect", $"Account connected. HWID: {hwid}, IP: {ip}"));
        }

        public void OnDisconnect()
        {
            ActiveCharacter = null;
            Connections.Add(new ConnectionEvent(ConnectionEventType.Disconnected, ip, hwid, "Account disconnected"));
            UpdateInContext();
            AltLogger.Instance.LogInfo(new AltAccountEvent(this, "Disconnect", "Account disconnected."));
        }

        #endregion

        public override string ToString() => $"{Username}_[{SocialClubId}]";
    }
}