using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoApp.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Email { get; set; }
        
        public string Name { get; set; }
        public string Surname { get; set; }

        public string Salt { get; set; }
        public string HashedPasswordAndSalt { get; set; }

        public ICollection<Task> Tasks { get; set; }

        public User()
        {
            Tasks = new List<Task>();
        }
    }
}