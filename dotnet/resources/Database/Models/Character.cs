using System;
using GTANetworkAPI;

namespace Database.Models
{
    public partial class Character : AbstractModel
    {
        private Character()
        {
        }

        public Character(Account account, string firstname, string lastname, DateTime birthday)
        {
            Account = account;
            FirstName = firstname;
            LastName = lastname;
            Birthday = birthday;
        }

        #region Main Data

        public Guid Id { get; private set; }

        public Account Account { get; private set; }
        
        #endregion

        public Vector3 LastPosition { get; set; }
        
        #region Biography

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public DateTime Birthday { get; private set; }
        
        #endregion

        #region Finances
        
        public long Cash { get; set; }

        #endregion
    }
}