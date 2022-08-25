using System;

namespace Database.Models
{
    public class Character : AbstractModel
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
            CreatedAt = DateTime.Now;
        }

        public Guid Id { get; private set; }

        public Account Account { get; private set; }

        public DateTime CreatedAt { get; private set; }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public DateTime Birthday { get; private set; }

        public long Cash { get; set; }
    }
}