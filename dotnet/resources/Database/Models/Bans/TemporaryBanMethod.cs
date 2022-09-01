using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database.Models.Bans
{
    public partial class TemporaryBan
    {
        [NotMapped] public DateTime EndDate => StartDate + Duration;

        public bool IsActual() => StartDate + Duration > DateTime.Now;
    }
}