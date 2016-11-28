using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Skroutz.Models
{
    public class Category
    {
            public int Id { get; set; }
            public string Name { get; set; }
            [Display(Name = "Subcategory of")]
            public int? ParentId { get; set; }
            public virtual Category Parent { get; set; } 
            public virtual ICollection<Category> Children { get; set; }
            public virtual ICollection<Product> Products { get; set; }
            public virtual ICollection<AttributeKey> Attributes { get; set; }
    }
}