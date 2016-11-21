using DiceShop.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DiceShop.Logic
{
    public class AppDBContext:DbContext
    {
        public DbSet<Dice> Dices { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }


    }
}