using DiceShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiceShop.ViewModels
{
    public class DiceViewModel
    {
        public Dice Dice { get; set; }
        public string color
        {
            get
            {
                if (Dice.IsRigged) return "red";
                return "black";
            }
        }
    }
}