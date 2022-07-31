using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Database.Models
{
    public enum UserEventType
    {
        Connected,
        Login,
        Disconnected
    }
    
    public class UserEvent
    {
        [Key]
        public int Id { get; set; }
        
        public UserEventType Type { get; set; }
        public DateTime DateTime { get; set; }
        public User User { get; set; }
    }
}