using DiceShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiceShop.Logic
{
    public static class MemoryRepository
    {
        public static List<Dice> Dices;
        public static List<Supplier> Suppliers;

        public static void Init()
        {
            Suppliers = new List<Supplier>()
            {
                new Supplier() {Id=1,Name="Sdasdff",Sirname="dd",MoneyOwed=1100,IsActive=true },
                new Supplier() {Id=2,Name="Sdasdff",Sirname="dd",MoneyOwed=1100,IsActive=true },
                new Supplier() {Id=3,Name="Sdadsff",Sirname="dd",MoneyOwed=1100,IsActive=true },
                new Supplier() {Id=4,Name="Sdadsff",Sirname="dd",MoneyOwed=1100,IsActive=true },
                new Supplier() {Id=5,Name="Sdasdf",Sirname="dd",MoneyOwed=1100,IsActive=true },
                new Supplier() {Id=6,Name="Sdf",Sirname="dd",MoneyOwed=1100,IsActive=true },
                new Supplier() {Id=7,Name="Sdadsf",Sirname="dd",MoneyOwed=1100,IsActive=true },
                new Supplier() {Id=8,Name="Sdadsf",Sirname="dd",MoneyOwed=1100,IsActive=true }
            };

            Dices = new List<Dice>()
            {
                new Dice() {Id=1,Name="Dice 1",CreationYear=1976, IsRigged=true,Supplier=Suppliers[0] },
                new Dice() {Id=2,Name="Dice 2",CreationYear=1976, IsRigged=true,Supplier=Suppliers[2] },
                new Dice() {Id=3,Name="Dice 3",CreationYear=1976, IsRigged=true,Supplier=Suppliers[3] },
                new Dice() {Id=4,Name="Dice 4",CreationYear=1976, IsRigged=true,Supplier=Suppliers[5] },
                new Dice() {Id=5,Name="Dice 5",CreationYear=1976, IsRigged=true,Supplier=Suppliers[1] },
                new Dice() {Id=6,Name="Dice 6",CreationYear=1976, IsRigged=true,Supplier=Suppliers[2] },
                new Dice() {Id=7,Name="yiDice 7",CreationYear=1976, IsRigged=true,Supplier=Suppliers[1] },
                new Dice() {Id=8,Name="yiDice 8",CreationYear=1976, IsRigged=true,Supplier=Suppliers[3] },
                new Dice() {Id=9,Name="Dice 9",CreationYear=1976, IsRigged=true,Supplier=Suppliers[2] },
                new Dice() {Id=10,Name="yi",CreationYear=1976, IsRigged=true,Supplier=Suppliers[1] }
            };

        }

        //public static List<DiceLite> GetDicesLite(string name)
        //{
        //    if (string.IsNullOrWhiteSpace(name))
        //    {
        //        //return Dices;
        //    }
        //    else
        //    {
        //        // Projection
        //        IEnumerable<DiceLite> ReturnList = 
        //            Dices.Where(x => x.Name.Contains(name))
        //            .Select(x=>new DiceLite() {
        //                id=x.Id,
        //                Name=x.Name
        //            });
        //        return ReturnList.ToList();
        //    }
        //}
        public static List<Dice> GetDices(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return Dices;
            }
            else
            {
                IEnumerable<Dice> ReturnList =  Dices.Where(x => x.Name.Contains(name));
                return ReturnList.ToList();
            }
        }
    }
}