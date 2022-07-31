using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Database.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        
        public DateTime RegisteredAt { get; set; }
        public string Name { get; set; }
        public string Nickname { get; set; }
        public List<double> Position { get; set; }
    }
}