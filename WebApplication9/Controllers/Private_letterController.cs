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
//    public class Private_letterController : Controller
//    {
//        private blogEntities db = new blogEntities();

//        // GET: Private_letter
//        public ActionResult Index()
//        {
//            var private_letter = db.Private_letter.Include(p => p.UserInfo).Include(p => p.UserInfo1);
//            return View(private_letter.ToList());
//        }

//        // GET: Private_letter/Details/5
//        public ActionResult Details(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            Private_letter private_letter = db.Private_letter.Find(id);
//            if (private_letter == null)
//            {
//                return HttpNotFound();
//            }
//            return View(private_letter);
//        }

//        // GET: Private_letter/Create
//        public ActionResult Create()
//        {
//            ViewBag.receiver_id = new SelectList(db.UserInfo, "User_id", "User_name");
//            ViewBag.senter_id = new SelectList(db.UserInfo, "User_id", "User_name");
//            return View();
//        }

//        // POST: Private_letter/Create
//        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
//        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Create([Bind(Include = "letter_id,senter_id,sent_time,receiver_id,content")] Private_letter private_letter)
//        {
//            if (ModelState.IsValid)
//            {
//                db.Private_letter.Add(private_letter);
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }

//            ViewBag.receiver_id = new SelectList(db.UserInfo, "User_id", "User_name", private_letter.receiver_id);
//            ViewBag.senter_id = new SelectList(db.UserInfo, "User_id", "User_name", private_letter.senter_id);
//            return View(private_letter);
//        }

//        // GET: Private_letter/Edit/5
//        public ActionResult Edit(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            Private_letter private_letter = db.Private_letter.Find(id);
//            if (private_letter == null)
//            {
//                return HttpNotFound();
//            }
//            ViewBag.receiver_id = new SelectList(db.UserInfo, "User_id", "User_name", private_letter.receiver_id);
//            ViewBag.senter_id = new SelectList(db.UserInfo, "User_id", "User_name", private_letter.senter_id);
//            return View(private_letter);
//        }

//        // POST: Private_letter/Edit/5
//        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
//        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Edit([Bind(Include = "letter_id,senter_id,sent_time,receiver_id,content")] Private_letter private_letter)
//        {
//            if (ModelState.IsValid)
//            {
//                db.Entry(private_letter).State = EntityState.Modified;
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }
//            ViewBag.receiver_id = new SelectList(db.UserInfo, "User_id", "User_name", private_letter.receiver_id);
//            ViewBag.senter_id = new SelectList(db.UserInfo, "User_id", "User_name", private_letter.senter_id);
//            return View(private_letter);
//        }

//        // GET: Private_letter/Delete/5
//        public ActionResult Delete(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            Private_letter private_letter = db.Private_letter.Find(id);
//            if (private_letter == null)
//            {
//                return HttpNotFound();
//            }
//            return View(private_letter);
//        }

//        // POST: Private_letter/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public ActionResult DeleteConfirmed(int id)
//        {
//            Private_letter private_letter = db.Private_letter.Find(id);
//            db.Private_letter.Remove(private_letter);
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
    public class Private_letterController : Controller
    {
        private blogEntities db = new blogEntities();

        // GET: Private_letter
        public ActionResult Index()
        {
            if (Session["userId"] != null)
            {
                var userId = Convert.ToInt32(Session["userId"].ToString());
                return View(db.Private_letter.Where(a => a.receiver_id == userId));
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }

        }

        // GET: Private_letter/Details/5
        public ActionResult Details(int id)
        {
            if (id < 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Private_letter private_letter = db.Private_letter.Find(id);
            if (private_letter == null)
            {
                return HttpNotFound();
            }
            return View(private_letter);
        }

        // GET: Private_letter/Create
        public ActionResult Create()
        {
            ViewBag.receiver = new SelectList(db.UserInfo, "User_id", "User_name");
            ViewBag.senter = new SelectList(db.UserInfo, "User_id", "User_name");
            return View();
        }

        // POST: Private_letter/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "letter_id,senter,sent_time,receiver,content")] Private_letter private_letter)
        {
            if (ModelState.IsValid)
            {
                db.Private_letter.Add(private_letter);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.receiver = new SelectList(db.UserInfo, "User_id", "User_name", private_letter.receiver_id);
            ViewBag.senter = new SelectList(db.UserInfo, "User_id", "User_name", private_letter.senter_id);
            return View(private_letter);
        }

        // GET: Private_letter/Edit/5
        public ActionResult Edit(int id)
        {
            if (id < 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Private_letter private_letter = db.Private_letter.Find(id);
            if (private_letter == null)
            {
                return HttpNotFound();
            }
            ViewBag.receiver = new SelectList(db.UserInfo, "User_id", "User_name", private_letter.receiver_id);
            ViewBag.senter = new SelectList(db.UserInfo, "User_id", "User_name", private_letter.senter_id);
            return View(private_letter);
        }

        // POST: Private_letter/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "letter_id,senter,sent_time,receiver,content")] Private_letter private_letter)
        {
            if (ModelState.IsValid)
            {
                db.Entry(private_letter).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.receiver = new SelectList(db.UserInfo, "User_id", "User_name", private_letter.receiver_id);
            ViewBag.senter = new SelectList(db.UserInfo, "User_id", "User_name", private_letter.senter_id);
            return View(private_letter);
        }

        // GET: Private_letter/Delete/5
        public ActionResult Delete(int id)
        {
            if (id < 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Private_letter private_letter = db.Private_letter.Find(id);
            if (private_letter == null)
            {
                return HttpNotFound();
            }
            return View(private_letter);
        }

        // POST: Private_letter/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Private_letter private_letter = db.Private_letter.Find(id);
            db.Private_letter.Remove(private_letter);
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

