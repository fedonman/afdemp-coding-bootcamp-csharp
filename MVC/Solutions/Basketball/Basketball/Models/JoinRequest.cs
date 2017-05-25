using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Basketball.Models
{
    public class JoinRequest
    {
        public int Id { get; set; }

        [ForeignKey("User")]
        public string UserName { get; set; }
        public User User { get; set; }
        
        [ForeignKey("Team")]
        public string TeamName { get; set; }
        public Team Team { get; set; }
    }
}