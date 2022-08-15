using System;

namespace Database.Models.AccountEvents
{
    public class AccountEvent
    {
        // EF .ctor
        protected AccountEvent()
        {
        }

        public AccountEvent(string ip, string hwid, string description = null)
        {
            Ip = ip;
            HWID = hwid;
            Description = description;
            DateTime = DateTime.Now;
        }
        
        public long Id { get; }

        public DateTime DateTime { get; }
        
        public string Ip { get; }
        
        public string HWID { get; }
        
        public string? Description { get; }
    }
}