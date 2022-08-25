using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database.Models.Bans
{
    public partial class TemporaryBan
    {
        public bool IsActual() => StartDate + Duration > DateTime.Now;

        [NotMapped] public DateTime EndDate => StartDate + Duration;
    }
}