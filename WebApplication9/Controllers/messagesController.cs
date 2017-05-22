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
//    public class messagesController : Controller
//    {
//        private blogEntities db = new blogEntities();

//        // GET: messages
//        public ActionResult Index()
//        {
//            var message = db.message.Include(m => m.UserInfo).Include(m => m.UserInfo1);
//            return View(message.ToList());
//        }

//        // GET: messages/Details/5
//        public ActionResult Details(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            message message = db.message.Find(id);
//            if (message == null)
//            {
//                return HttpNotFound();
//            }
//            return View(message);
//        }

//        // GET: messages/Create
//        public ActionResult Create()
//        {
//            ViewBag.recipient_id = new SelectList(db.UserInfo, "User_id", "User_name");
//            ViewBag.writer_id = new SelectList(db.UserInfo, "User_id", "User_name");
//            return View();
//        }

//        // POST: messages/Create
//        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
//        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Create([Bind(Include = "message_id,writer_id,message_time,recipient_id,content")] message message)
//        {
//            if (ModelState.IsValid)
//            {
//                db.message.Add(message);
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }

//            ViewBag.recipient_id = new SelectList(db.UserInfo, "User_id", "User_name", message.recipient_id);
//            ViewBag.writer_id = new SelectList(db.UserInfo, "User_id", "User_name", message.writer_id);
//            return View(message);
//        }

//        // GET: messages/Edit/5
//        public ActionResult Edit(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            message message = db.message.Find(id);
//            if (message == null)
//            {
//                return HttpNotFound();
//            }
//            ViewBag.recipient_id = new SelectList(db.UserInfo, "User_id", "User_name", message.recipient_id);
//            ViewBag.writer_id = new SelectList(db.UserInfo, "User_id", "User_name", message.writer_id);
//            return View(message);
//        }

//        // POST: messages/Edit/5
//        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
//        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Edit([Bind(Include = "message_id,writer_id,message_time,recipient_id,content")] message message)
//        {
//            if (ModelState.IsValid)
//            {
//                db.Entry(message).State = EntityState.Modified;
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }
//            ViewBag.recipient_id = new SelectList(db.UserInfo, "User_id", "User_name", message.recipient_id);
//            ViewBag.writer_id = new SelectList(db.UserInfo, "User_id", "User_name", message.writer_id);
//            return View(message);
//        }

//        // GET: messages/Delete/5
//        public ActionResult Delete(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            message message = db.message.Find(id);
//            if (message == null)
//            {
//                return HttpNotFound();
//            }
//            return View(message);
//        }

//        // POST: messages/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public ActionResult DeleteConfirmed(int id)
//        {
//            message message = db.message.Find(id);
//            db.message.Remove(message);
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
    public class messagesController : Controller
    {
        private blogEntities db = new blogEntities();

        // GET: messages
        public ActionResult Index()
        {
            if (Session["userId"] != null)
            {
                var userId = Convert.ToInt32(Session["userId"].ToString());
                return View(db.message.Where(a => a.recipient_id == userId));
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }

        }
        // GET: messages/Details/5
        public ActionResult Details(int id)
        {
            if (id < 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            message message = db.message.Find(id);
            if (message == null)
            {
                return HttpNotFound();
            }
            return View(message);
        }

        // GET: messages/Create
        public ActionResult Create()
        {
            ViewBag.Guestbook = new SelectList(db.UserInfo, "User_id", "User_name");
            ViewBag.recipient = new SelectList(db.UserInfo, "User_id", "User_name");
            return View();
        }

        // POST: messages/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "message_id,Guestbook,message_time,recipient,content")] message message)
        {
            if (ModelState.IsValid)
            {
                db.message.Add(message);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Guestbook = new SelectList(db.UserInfo, "User_id", "User_name", message.writer_id);
            ViewBag.recipient = new SelectList(db.UserInfo, "User_id", "User_name", message.recipient_id);
            return View(message);
        }

        // GET: messages/Edit/5
        public ActionResult Edit(int id)
        {
            if (id < 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            message message = db.message.Find(id);
            if (message == null)
            {
                return HttpNotFound();
            }
            ViewBag.Guestbook = new SelectList(db.UserInfo, "User_id", "User_name", message.writer_id);
            ViewBag.recipient = new SelectList(db.UserInfo, "User_id", "User_name", message.recipient_id);
            return View(message);
        }

        // POST: messages/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "message_id,Guestbook,message_time,recipient,content")] message message)
        {
            if (ModelState.IsValid)
            {
                db.Entry(message).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Guestbook = new SelectList(db.UserInfo, "User_id", "User_name", message.writer_id);
            ViewBag.recipient = new SelectList(db.UserInfo, "User_id", "User_name", message.recipient_id);
            return View(message);
        }

        // GET: messages/Delete/5
        public ActionResult Delete(int id)
        {
            if (id < 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            message message = db.message.Find(id);
            if (message == null)
            {
                return HttpNotFound();
            }
            return View(message);
        }

        // POST: messages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            message message = db.message.Find(id);
            db.message.Remove(message);
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

