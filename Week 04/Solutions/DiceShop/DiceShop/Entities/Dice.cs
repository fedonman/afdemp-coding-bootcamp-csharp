using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DiceShop.Entities
{
    public class Dice
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public int CreationYear { get; set; }
        public bool IsRigged { get; set; }
        public Supplier Supplier { get; set; }
        [NotMapped]
        public string color
        {
            get
            {
                if (IsRigged) return "red";
                return "black";
            }
        }
        public int SupplierId { get; set; }
    }
}