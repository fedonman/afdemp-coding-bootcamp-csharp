using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_1.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}