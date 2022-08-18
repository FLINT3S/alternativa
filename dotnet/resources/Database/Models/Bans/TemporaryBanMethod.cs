using System;

namespace Database.Models.Bans
{
    public partial class TemporaryBan
    {
        public bool IsActual() => StartDate + Duration > DateTime.Now;
    }
}