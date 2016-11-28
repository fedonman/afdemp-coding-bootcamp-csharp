using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace Skroutz.Models
{
    public class Store
    {
        public int Id { get; set; }
        [Display(Name = "Store")]
        public string Name { get; set; }
        public string Web { get; set; }
        public string Headquarters { get; set; }
        public string Phone { get; set; }
        public virtual ICollection<Inventory> Inventory { get; set; }
    }
}