using DiceShop.Entities;
using DiceShop.Logic;
using DiceShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DiceShop.Controllers
{
    public class DiceController : Controller
    {
        public DiceController()
        {
            MemoryRepository.Init();
        }
        // GET: Home
        public ActionResult List(string name)
        {
            List<DicesViewModel> VM = new List<DicesViewModel>();

            //Fetch data from repository
            //List<Dice> Dices=MemoryRepository.GetDices(name);
            List<Dice> Dices = DBRepository.GetDices(name);

            //Create the view
            foreach (Dice d in Dices)
                VM.Add(DicesViewModel.GetDiceViewModelFromDice(d));

            return View(VM);
        }
        public ActionResult Error(string message)
        {
            return View(message);
        }

        public ActionResult ViewItem(int itemId)
        {
            return View();
        }

        public ActionResult EditItem(int itemId)
        {
            if (itemId != -1)
            {
                Dice d = DBRepository.GetDice(itemId);
                if (d == null)
                    return RedirectToAction("Error", new { message = "Το id δεν βρέθηκε" });

                return View(d);
            }
            else
            {
                Dice d = new Dice()
                {
                    Id=-1,
                    Name="-",
                    CreationYear=DateTime.Now.Year,
                    IsRigged=false
                };

                return View(d);
            }
        }

        public ActionResult EditItemPost(Dice d)
        {
            SaveResult Result= DBRepository.Save(d);
            if (Result.Status == false)
            {
                return RedirectToAction("Error", new { message =Result.Message});
            }

            return RedirectToAction("List", "Dice");
        }
        public ActionResult DeleteItem(int itemId)
        {
            return View();
        }
    }
}