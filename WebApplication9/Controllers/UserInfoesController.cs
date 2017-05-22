//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.Entity;
//using System.Linq;
//using System.Net;
//using System.Web;
//using System.Web.Mvc;
//using Blog.Models;

//namespace Blog.Controllers
//{
//    public class UserInfoesController : Controller
//    {
//        private blogEntities db = new blogEntities();

//        // GET: UserInfoes
//        public ActionResult Index()
//        {
//            return View(db.UserInfo.ToList());
//        }

//        // GET: UserInfoes/Details/5
//        public ActionResult Details(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            UserInfo userInfo = db.UserInfo.Find(id);
//            if (userInfo == null)
//            {
//                return HttpNotFound();
//            }
//            return View(userInfo);
//        }

//        // GET: UserInfoes/Create
//        public ActionResult Create()
//        {
//            return View();
//        }

//        // POST: UserInfoes/Create
//        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
//        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Create([Bind(Include = "User_id,User_name,password,balance,phone,Sex,birthdate")] UserInfo userInfo)
//        {
//            if (ModelState.IsValid)
//            {
//                db.UserInfo.Add(userInfo);
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }

//            return View(userInfo);
//        }

//        // GET: UserInfoes/Edit/5
//        public ActionResult Edit(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            UserInfo userInfo = db.UserInfo.Find(id);
//            if (userInfo == null)
//            {
//                return HttpNotFound();
//            }
//            return View(userInfo);
//        }

//        // POST: UserInfoes/Edit/5
//        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
//        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Edit([Bind(Include = "User_id,User_name,password,balance,phone,Sex,birthdate")] UserInfo userInfo)
//        {
//            if (ModelState.IsValid)
//            {
//                db.Entry(userInfo).State = EntityState.Modified;
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }
//            return View(userInfo);
//        }

//        // GET: UserInfoes/Delete/5
//        public ActionResult Delete(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            UserInfo userInfo = db.UserInfo.Find(id);
//            if (userInfo == null)
//            {
//                return HttpNotFound();
//            }
//            return View(userInfo);
//        }

//        // POST: UserInfoes/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public ActionResult DeleteConfirmed(int id)
//        {
//            UserInfo userInfo = db.UserInfo.Find(id);
//            db.UserInfo.Remove(userInfo);
//            db.SaveChanges();
//            return RedirectToAction("Index");
//        }

//        protected override void Dispose(bool disposing)
//        {
//            if (disposing)
//            {
//                db.Dispose();
//            }
//            base.Dispose(disposing);
//        }
//    }
//}


using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Blog.Models;

namespace Blog.Controllers
{

    public class UserInfoesController : Controller
    {
        private blogEntities db = new blogEntities();

        // GET: UserInfoes
        public ActionResult Index()
        {
            if (Session["userId"] != null)
            {
                var userId = Convert.ToInt32(Session["userId"].ToString());
                return View(db.UserInfo.Where(a => a.User_id == userId));
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }

        }

        // GET: UserInfoes/Details/5
        public ActionResult Details(int id)
        {
            if (id < 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserInfo userInfo = db.UserInfo.Find(id);
            if (userInfo == null)
            {
                return HttpNotFound();
            }
            return View(userInfo);
        }

        // GET: UserInfoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserInfoes/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "User_id,User_name,password,balance,phone,Sex,birthdate,Head_portrait")] UserInfo userInfo)
        {
            if (ModelState.IsValid)
            {
                db.UserInfo.Add(userInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userInfo);
        }

        // GET: UserInfoes/Edit/5
        public ActionResult Edit(int id)
        {
            if (id < 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserInfo userInfo = db.UserInfo.Find(id);
            if (userInfo == null)
            {
                return HttpNotFound();
            }
            return View(userInfo);
        }

        // POST: UserInfoes/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "User_id,User_name,password,balance,phone,Sex,birthdate,Head_portrait")] UserInfo userInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userInfo);
        }

        // GET: UserInfoes/Delete/5
        public ActionResult Delete(int id)
        {
            if (id < 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserInfo userInfo = db.UserInfo.Find(id);
            if (userInfo == null)
            {
                return HttpNotFound();
            }
            return View(userInfo);
        }

        // POST: UserInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserInfo userInfo = db.UserInfo.Find(id);
            db.UserInfo.Remove(userInfo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        //public ActionResult UserInfo(int id)
        //{

        //    int user = from u in db.UserInfo
        //               where u.User_id == id
        //               select u;

        //    return View(user.ToList());
        //}

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

