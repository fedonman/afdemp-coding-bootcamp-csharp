using DiceShop.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DiceShop.Logic
{
    public class SaveResult
    {
        public bool Status { get; set; }
        public string Message { get; set; }
    }
    public static class DBRepository
    {

        public static SaveResult Save(Dice d)
        {
            using (AppDBContext ctx = new AppDBContext())
            {
                if (d.Id != -1)
                {
                    Dice DiceInDB = ctx.Dices.FirstOrDefault(x => x.Id == d.Id);
                    if (DiceInDB == null)
                    {
                        return new SaveResult()
                        {
                            Status = false,
                            Message = "Dice not found in database"
                        };
                    }

                    DiceInDB.Name = d.Name;
                    DiceInDB.CreationYear = d.CreationYear;
                }
                else
                {
                    Dice NewDiceForDB = new Dice();
                    NewDiceForDB.Name = d.Name;
                    NewDiceForDB.CreationYear = d.CreationYear;

                    ctx.Dices.Add(NewDiceForDB);
                }


                try
                {
                    ctx.SaveChanges();
                    return new SaveResult()
                    {
                        Status = true,
                        Message = ""
                    };
                }
                catch(Exception e)
                {
                    return new SaveResult()
                    {
                        Status = false,
                        Message = e.Message
                    };
                }
            }
        }
        public static Dice GetDice(int id)
        {
            using (AppDBContext ctx = new AppDBContext())
            {
                Dice d = ctx.Dices.FirstOrDefault(x => x.Id == id);
                return d;  
            }
        }
        public static List<Dice> GetDices(string name)
        {
            using (AppDBContext ctx=new AppDBContext())
            {
                if (string.IsNullOrWhiteSpace(name))
                {
                    return ctx.Dices.Include("Supplier").ToList() ;
                }
                else
                {
                    IQueryable<Dice> ReturnList =ctx.Dices.Include("Supplier").Where(x => x.Name.Contains(name));
                    return ReturnList.ToList();
                }

            }

            //if (string.IsNullOrWhiteSpace(name))
            //{
            //    return Dices;
            //}
            //else
            //{
            //    IEnumerable<Dice> ReturnList =  Dices.Where(x => x.Name.Contains(name));
            //    return ReturnList.ToList();
            //}
        }
    }
}