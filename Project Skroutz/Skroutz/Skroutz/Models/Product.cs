using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Skroutz.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Display(Name="Category")]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<Inventory> Inventory { get; set; }
        public virtual ICollection<AttributeValue> Attributes { get; set; }
    }
}