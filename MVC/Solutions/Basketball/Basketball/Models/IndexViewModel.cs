using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Basketball.Models
{
    public class IndexViewModel
    {
        public List<Team> Teams { get; set; }
        public User User { get; set; }
    }
}