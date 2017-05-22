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
//    public class concernsController : Controller
//    {
//        private blogEntities db = new blogEntities();

//        // GET: concerns
//        public ActionResult Index()
//        {
//            var concern = db.concern.Include(c => c.UserInfo).Include(c => c.UserInfo1);
//            return View(concern.ToList());
//        }

//        // GET: concerns/Details/5
//        public ActionResult Details(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            concern concern = db.concern.Find(id);
//            if (concern == null)
//            {
//                return HttpNotFound();
//            }
//            return View(concern);
//        }

//        // GET: concerns/Create
//        public ActionResult Create()
//        {
//            ViewBag.concerned_id = new SelectList(db.UserInfo, "User_id", "User_name");
//            ViewBag.follower_id = new SelectList(db.UserInfo, "User_id", "User_name");
//            return View();
//        }

//        // POST: concerns/Create
//        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
//        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Create([Bind(Include = "concern_id,follower_id,concerned_id")] concern concern)
//        {
//            if (ModelState.IsValid)
//            {
//                db.concern.Add(concern);
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }

//            ViewBag.concerned_id = new SelectList(db.UserInfo, "User_id", "User_name", concern.concerned_id);
//            ViewBag.follower_id = new SelectList(db.UserInfo, "User_id", "User_name", concern.follower_id);
//            return View(concern);
//        }

//        // GET: concerns/Edit/5
//        public ActionResult Edit(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            concern concern = db.concern.Find(id);
//            if (concern == null)
//            {
//                return HttpNotFound();
//            }
//            ViewBag.concerned_id = new SelectList(db.UserInfo, "User_id", "User_name", concern.concerned_id);
//            ViewBag.follower_id = new SelectList(db.UserInfo, "User_id", "User_name", concern.follower_id);
//            return View(concern);
//        }

//        // POST: concerns/Edit/5
//        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
//        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Edit([Bind(Include = "concern_id,follower_id,concerned_id")] concern concern)
//        {
//            if (ModelState.IsValid)
//            {
//                db.Entry(concern).State = EntityState.Modified;
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }
//            ViewBag.concerned_id = new SelectList(db.UserInfo, "User_id", "User_name", concern.concerned_id);
//            ViewBag.follower_id = new SelectList(db.UserInfo, "User_id", "User_name", concern.follower_id);
//            return View(concern);
//        }

//        // GET: concerns/Delete/5
//        public ActionResult Delete(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            concern concern = db.concern.Find(id);
//            if (concern == null)
//            {
//                return HttpNotFound();
//            }
//            return View(concern);
//        }

//        // POST: concerns/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public ActionResult DeleteConfirmed(int id)
//        {
//            concern concern = db.concern.Find(id);
//            db.concern.Remove(concern);
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
    public class concernsController : Controller
    {
        private blogEntities db = new blogEntities();

        // GET: concerns
        public ActionResult Index()
        {
            if (Session["userId"] != null)
            {
                var userId = Convert.ToInt32(Session["userId"].ToString());
                return View(db.concern.Where(a => a.follower_id == userId));
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }

        }

        // GET: concerns/Details/5
        public ActionResult Details(int id)
        {
            if (id < 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            concern concern = db.concern.Find(id);
            if (concern == null)
            {
                return HttpNotFound();
            }
            return View(concern);
        }

        // GET: concerns/Create
        public ActionResult Create()
        {
            ViewBag.concerned = new SelectList(db.UserInfo, "User_id", "User_name");
            ViewBag.follower = new SelectList(db.UserInfo, "User_id", "User_name");
            return View();
        }

        // POST: concerns/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "concern_id,follower,concerned")] concern concern)
        {
            if (ModelState.IsValid)
            {
                db.concern.Add(concern);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.concerned = new SelectList(db.UserInfo, "User_id", "User_name", concern.concerned_id);
            ViewBag.follower = new SelectList(db.UserInfo, "User_id", "User_name", concern.follower_id);
            return View(concern);
        }

        // GET: concerns/Edit/5
        public ActionResult Edit(int id)
        {
            if (id < 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            concern concern = db.concern.Find(id);
            if (concern == null)
            {
                return HttpNotFound();
            }
            ViewBag.concerned = new SelectList(db.UserInfo, "User_id", "User_name", concern.concerned_id);
            ViewBag.follower = new SelectList(db.UserInfo, "User_id", "User_name", concern.follower_id);
            return View(concern);
        }

        // POST: concerns/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "concern_id,follower,concerned")] concern concern)
        {
            if (ModelState.IsValid)
            {
                db.Entry(concern).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.concerned = new SelectList(db.UserInfo, "User_id", "User_name", concern.concerned_id);
            ViewBag.follower = new SelectList(db.UserInfo, "User_id", "User_name", concern.follower_id);
            return View(concern);
        }

        // GET: concerns/Delete/5
        public ActionResult Delete(int id)
        {
            if (id < 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            concern concern = db.concern.Find(id);
            if (concern == null)
            {
                return HttpNotFound();
            }
            return View(concern);
        }

        // POST: concerns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            concern concern = db.concern.Find(id);
            db.concern.Remove(concern);
            db.SaveChanges();
            return RedirectToAction("Index");
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

