using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Helpers;
using System.Web.Security;

using System.Data.Entity;
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
            ViewBag.BaseUrl = Request.Url.GetLeftPart(UriPartial.Authority) + Url.Content("~");
            ViewBag.UserEmail = Session["UserEmail"];
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
                Session["UserEmail"] = u.Email;
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
            Session.Remove("UserEmail");
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

        [Authorize]
        [HttpGet]
        public ActionResult GetTasks(string email)
        {
            var tasks = db.Tasks.Where(x => x.User.Email == email).Select(x => new { Id = x.Id, Title = x.Title, IsCompleted = x.IsCompleted }).ToList();
            return Json(tasks, JsonRequestBehavior.AllowGet);
        }

        [Authorize]
        [HttpPost]
        public ActionResult ToggleTask(int id)
        {
            Task task = db.Tasks.Find(id);
            if (task == null)
            {
                return new HttpStatusCodeResult(404, "Task not found");
            }
            task.IsCompleted = !task.IsCompleted;
            db.Entry(task).State = EntityState.Modified;
            db.SaveChanges();
            return new HttpStatusCodeResult(204, "Task status toggled sucessfully.");
        }

        [Authorize]
        [HttpPost]
        public ActionResult DeleteTask(int id)
        {
            Task task = db.Tasks.Find(id);
            if (task == null)
            {
                return new HttpStatusCodeResult(404, "Task not found.");
            }
            db.Entry(task).State = EntityState.Deleted;
            db.SaveChanges();
            return new HttpStatusCodeResult(204, "Task deleted successfully.");
        }

        [Authorize]
        [HttpPost]
        [Route("api/tasks/create")]
        public ActionResult CreateTask(Task task)
        {
            db.Tasks.Add(task);
            db.SaveChanges();

            return Json(task.Id);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}