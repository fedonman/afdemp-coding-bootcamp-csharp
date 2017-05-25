using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Basketball.Models
{
    public class Team
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Name { get; set; }

        [ForeignKey("Creator")]
        public string CreatorEmail { get; set; }
        public User Creator { get; set; }

        public virtual ICollection<User> Members { get; set; }
    }
}