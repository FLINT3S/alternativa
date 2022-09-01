using System;
using GTANetworkAPI;

namespace Database.Models
{
    public partial class Character : AbstractModel
    {
        protected Character()
        {
        }

        public Character(Account account, string firstname, string lastname, DateTime birthday)
        {
            Account = account;
            FirstName = firstname;
            LastName = lastname;
            Birthday = birthday;
            InGameTime = TimeSpan.Zero;
        }

        public Vector3 LastPosition { get; private set; }

        private TimeSpan TimeToReborn { get; set; } = TimeSpan.Zero;

        #region Finances

        public long Cash { get; set; }

        #endregion

        #region Main Data

        public Guid Id { get; private set; }

        public Account Account { get; private set; }
        
        public TimeSpan InGameTime { get; private set; } = TimeSpan.Zero;

        #endregion

        #region Biography

        public string FirstName { get; }

        public string LastName { get; }

        public DateTime Birthday { get; }

        #endregion
    }
}