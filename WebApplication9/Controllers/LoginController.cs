using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Blog.Models;


namespace Blog.Controllers
{
    public class LoginController : Controller
    {
        private blogEntities db = new blogEntities();
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserInfo user)
        {
            var userinfo = db.UserInfo.FirstOrDefault(u => u.User_name == user.User_name && u.password == user.password);
            if (userinfo != null)
            {
                Session.Add("userId", userinfo.User_id);
                Session.Add("userName", userinfo.User_name);
                //ViewBag.LoginState = userinfo.userId;
                return RedirectToAction("Index", "Articles1");

            }
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register([Bind(Include = "User_name,password")] UserInfo user)
        {
            if (ModelState.IsValid)
            {
                db.UserInfo.Add(user);
                db.SaveChanges();
                return RedirectToAction("Login");
            }

           
            return View(user);

            
        }
    }
}