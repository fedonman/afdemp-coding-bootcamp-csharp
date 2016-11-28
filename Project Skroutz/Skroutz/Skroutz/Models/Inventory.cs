using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Skroutz.Models
{
    public class Inventory
    {
        [Key]
        [Column(Order = 1)]
        [ForeignKey("Product")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Product")]
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        [Key]
        [Column(Order = 2)]
        [ForeignKey("Store")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Store")]
        public int StoreId { get; set; }
        public virtual Store Store { get; set; }
        public decimal Price { get; set; }

    }
}