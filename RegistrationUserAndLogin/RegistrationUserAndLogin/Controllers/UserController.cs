using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RegistrationUserAndLogin.Models;
using System.Data.Entity;

namespace RegistrationUserAndLogin.Controllers
{
    public class UserController : Controller
    {
        private MyDatabaseEntities db = new MyDatabaseEntities();
        // GET: User
        public ActionResult Index()
        {
            using (MyDatabaseEntities db = new MyDatabaseEntities())
            {
                return View(db.Users.ToList());
            }
                
        }
        [HttpGet]
        public ActionResult Register()
        {
            User usr = new User();
            return View(usr);
        }

        [HttpPost]
        public ActionResult Register(User usr)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(usr);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Error occured!!!");
            }
            return View(usr);
            //using (MyDatabaseEntities db = new MyDatabaseEntities())
            //{
            //    if(db.Users.Any(x => x.Username == usr.Username))
            //    {
            //        ViewBag.DuplicateMessage= "UserName already exist.";
            //        return View("Register", usr);
            //    }
            //    db.Users.Add(usr);
            //    db.SaveChanges();
            //}
            //ModelState.Clear();
            //ViewBag.SuccessfulMessage = "Registration successful.";
            //return View("Register", new User());
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login (User usr)
        {
            using (MyDatabaseEntities db = new MyDatabaseEntities())
            {
                var obj = db.Users.Where(u => u.Username.Equals(usr.Username) && u.Password.Equals(usr.Password)).FirstOrDefault();
                if (obj != null)
                {
                    Session["UserID"] = obj.UserID.ToString();
                    Session["Username"] = obj.Username.ToString();
                    return RedirectToAction("LoggedIn");
                }
                else
                {
                    ViewBag.LoginFailMessage = "Fail! Username or Password is wrong.";
                    return View("Login");
                }
            }
        }

        public ActionResult LoggedIn()
        {
            if(Session["UserID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public ActionResult Edit(int id)
        {
            using (MyDatabaseEntities db = new MyDatabaseEntities())
            {
                return View(db.Users.Where(u => u.UserID == id).FirstOrDefault());
            }
        }

        [HttpPost]
        public ActionResult Edit(int id, User usr)
        {
            try
            {
                using (MyDatabaseEntities db = new MyDatabaseEntities())
                {
                    db.Entry(usr).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}