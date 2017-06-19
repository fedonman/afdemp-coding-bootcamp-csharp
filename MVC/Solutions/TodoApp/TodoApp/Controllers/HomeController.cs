using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Helpers;
using System.Web.Security;

using TodoApp.Models;
using TodoApp.ViewModels;

namespace TodoApp.Controllers
{
    public class HomeController : Controller
    {
        private MyContext db = new MyContext();

        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult Login(LoginViewModel loginViewModel)
        {
            User u = db.Users.Find(loginViewModel.Email);
            if (u == null)
            {
                ViewBag.EmailNotExists = true;
                return View(loginViewModel);
            }
            if (Crypto.VerifyHashedPassword(u.HashedPasswordAndSalt, String.Concat(loginViewModel.Password, u.Salt)))
            {
                FormsAuthentication.SetAuthCookie(u.Email, false);
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.NotMatching = true;
                return View(loginViewModel);
            }
        }

        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult Register(RegisterViewModel registerViewModel)
        {
            if (db.Users.Find(registerViewModel.Email) == null)
            {
                User u = new User();
                u.Email = registerViewModel.Email;
                u.Name = registerViewModel.Name;
                u.Surname = registerViewModel.Surname;
                u.Salt = Crypto.GenerateSalt();
                u.HashedPasswordAndSalt = Crypto.HashPassword(String.Concat(registerViewModel.Password, u.Salt));

                db.Users.Add(u);
                db.SaveChanges();
                return RedirectToAction("Login");
            }
            else
            {
                ViewBag.EmailExists = true;
                return View(registerViewModel);
            }
        }

        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}