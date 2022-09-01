using System;
using System.Diagnostics.CodeAnalysis;

namespace Database.Models.AccountEvents
{
    [SuppressMessage("ReSharper", "AutoPropertyCanBeMadeGetOnly.Local")]
    [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Local")]
    public class AccountEvent : AbstractModel
    {
        // EF .ctor
        protected AccountEvent()
        {
        }

        protected AccountEvent(string ip, string hwid, string description = null)
        {
            Ip = ip;
            HWID = hwid;
            Description = description;
            DateTime = DateTime.Now;
        }

        public long Id { get; private set; }

        public DateTime DateTime { get; private set; }

        public string Ip { get; private set; }

        public string HWID { get; private set; }

        public string Description { get; private set; }
    }
}