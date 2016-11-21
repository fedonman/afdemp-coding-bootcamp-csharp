using DiceShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiceShop.ViewModels
{
    public class DicesViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsRigged { get; set; }

        public string SupplierName { get; set; }


        public static DicesViewModel GetDiceViewModelFromDice(Dice Dice)
        {
            return new DicesViewModel()
            {
                Id = Dice.Id,
                IsRigged = Dice.IsRigged,
                Name = Dice.Name,
                SupplierName = Dice.Supplier == null ? "?" : Dice.Supplier.Sirname + " " + Dice.Supplier.Name

            };
        }
    }
}