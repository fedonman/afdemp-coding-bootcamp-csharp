using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Basketball.Models;

namespace Basketball.Controllers
{
    public class HomeController : Controller
    {
        private MyContext db = new MyContext();

        public ActionResult Index()
        {
            if (Session["Email"] == null)
            {
                return RedirectToAction("Login");
            }
            IndexViewModel viewModel = new IndexViewModel();
            viewModel.Teams = db.Teams.Include("Members").ToList();
            viewModel.User = db.Users.Find((string)Session["Email"]);
            return View(viewModel);
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User user)
        {
            User u = db.Users.Find(user.Email);
            if (u == null)
            {
                ViewBag.EmailNotExists = true;
                return View(user);
            }
            if (u.Password == user.Password)
            {
                // Login Successful
                Session.Add("Email", user.Email);
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.NotMatching = true;
                return View(user);
            }
        }

        public ActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Signup(User user)
        {
            if (db.Users.Find(user.Email) == null)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Login");
            }
            else
            {
                ViewBag.EmailExists = true;
                return View(user);
            }
        }

        public ActionResult CreateTeam()
        {
            if (Session["Email"] == null)
            {
                return RedirectToAction("Login");
            }
            User u = db.Users.Find((string)Session["Email"]);
            if (u == null)
            {
                return RedirectToAction("Login");
            }
            if (u.Team == null)
            {
                Team team = new Team();
                team.CreatorEmail = u.Email;
                return View(team);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateTeam(Team team)
        {
            if (db.Teams.Find(team.Name) == null)
            {
                db.Teams.Add(team);
                db.SaveChanges();
                User u = db.Users.Find(team.CreatorEmail);
                u.TeamName = team.Name;
                db.Entry(u).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.NameExists = true;
                return View(team);
            }
        }

        public ActionResult JoinRequest(string userEmail, string teamName)
        {
            if (Session["Email"] == null)
            {
                return RedirectToAction("Login");
            }
            if ((string)Session["Email"] != userEmail)
            {
                return RedirectToAction("Index");
            }
            JoinRequest request = new JoinRequest { UserName = userEmail, TeamName = teamName };
            db.JoinRequests.Add(request);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ViewRequests()
        {
            if (Session["Email"] == null)
            {
                return RedirectToAction("Login");
            }
            ViewRequestsViewModel viewModel = new ViewRequestsViewModel();
            viewModel.User = db.Users.Find((string)Session["Email"]);
            viewModel.Requests = db.JoinRequests.Where(x => x.Team.CreatorEmail == user.Email).ToList();
            return View(viewModel);
        }
    }
}