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
//    public class qiantaiController : Controller
//    {
//        private blogEntities db = new blogEntities();

//        // GET: qiantai
//        public ActionResult Index()
//        {
//            var article = db.Article.Include(a => a.UserInfo);
//            return View(article.ToList());
//        }

//        // GET: qiantai/Details/5
//        public ActionResult Details(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            Article article = db.Article.Find(id);
//            if (article == null)
//            {
//                return HttpNotFound();
//            }
//            return View(article);
//        }

//        // GET: qiantai/Create
//        public ActionResult Create()
//        {
//            ViewBag.User_id = new SelectList(db.UserInfo, "User_id", "User_name");
//            return View();
//        }

//        // POST: qiantai/Create
//        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
//        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Create([Bind(Include = "Article_id,Article_title,Article_text,User_id,Visit_quantity,Release_time,Category")] Article article)
//        {
//            if (ModelState.IsValid)
//            {
//                db.Article.Add(article);
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }

//            ViewBag.User_id = new SelectList(db.UserInfo, "User_id", "User_name", article.User_id);
//            return View(article);
//        }

//        // GET: qiantai/Edit/5
//        public ActionResult Edit(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            Article article = db.Article.Find(id);
//            if (article == null)
//            {
//                return HttpNotFound();
//            }
//            ViewBag.User_id = new SelectList(db.UserInfo, "User_id", "User_name", article.User_id);
//            return View(article);
//        }

//        // POST: qiantai/Edit/5
//        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
//        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Edit([Bind(Include = "Article_id,Article_title,Article_text,User_id,Visit_quantity,Release_time,Category")] Article article)
//        {
//            if (ModelState.IsValid)
//            {
//                db.Entry(article).State = EntityState.Modified;
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }
//            ViewBag.User_id = new SelectList(db.UserInfo, "User_id", "User_name", article.User_id);
//            return View(article);
//        }

//        // GET: qiantai/Delete/5
//        public ActionResult Delete(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            Article article = db.Article.Find(id);
//            if (article == null)
//            {
//                return HttpNotFound();
//            }
//            return View(article);
//        }

//        // POST: qiantai/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public ActionResult DeleteConfirmed(int id)
//        {
//            Article article = db.Article.Find(id);
//            db.Article.Remove(article);
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
    public class QiantaiController : Controller
    {
        private blogEntities db = new blogEntities();

        // GET: Qiantai
        public ActionResult Index()
        {
            var article = db.Article.Include(a => a.UserInfo);
            return View(article.ToList());
        }

        // GET: Qiantai/Details/5
        public ActionResult Details(int id)
        {
            if (id < 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = db.Article.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        // GET: Qiantai/Create
        public ActionResult Create()
        {
            ViewBag.User_id = new SelectList(db.UserInfo, "User_id", "User_name");
            return View();
        }

        // POST: Qiantai/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Article_id,Article_title,Article_text,User_id,Visit_quantity,Release_time,Category")] Article article)
        {
            if (ModelState.IsValid)
            {
                db.Article.Add(article);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.User_id = new SelectList(db.UserInfo, "User_id", "User_name", article.User_id);
            return View(article);
        }

        // GET: Qiantai/Edit/5
        public ActionResult Edit(int id)
        {
            if (id < 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = db.Article.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            ViewBag.User_id = new SelectList(db.UserInfo, "User_id", "User_name", article.User_id);
            return View(article);
        }

        // POST: Qiantai/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Article_id,Article_title,Article_text,User_id,Visit_quantity,Release_time,Category")] Article article)
        {
            if (ModelState.IsValid)
            {
                db.Entry(article).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.User_id = new SelectList(db.UserInfo, "User_id", "User_name", article.User_id);
            return View(article);
        }

        // GET: Qiantai/Delete/5
        public ActionResult Delete(int id)
        {
            if (id < 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = db.Article.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        // POST: Qiantai/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Article article = db.Article.Find(id);
            db.Article.Remove(article);
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

