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
        
        public Guid Id { get; }
        
        public Account Account { get; }
        
        public DateTime CreatedAt { get; }
        
        public string FirstName { get; }
        
        public string LastName { get; }
        
        public DateTime Birthday { get; }
        
        public long Cash { get; set; }
    }
}