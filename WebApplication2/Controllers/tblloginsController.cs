using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication2;

namespace WebApplication2.Controllers
{
    public class tblloginsController : Controller
    {
        private Entities db = new Entities();

        // GET: tbllogins
        public ActionResult Index()
        {
            return View(db.tbllogin.ToList());
        }

        // GET: tbllogins/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbllogin tbllogin = db.tbllogin.Find(id);
            if (tbllogin == null)
            {
                return HttpNotFound();
            }
            return View(tbllogin);
        }

        // GET: tbllogins/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tbllogins/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Uid,BadgeNumber,UserName,pass,endloginTime,persianName,UEnable")] tbllogin tbllogin)
        {
            if (ModelState.IsValid)
            {
                db.tbllogin.Add(tbllogin);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbllogin);
        }

        // GET: tbllogins/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbllogin tbllogin = db.tbllogin.Find(id);
            if (tbllogin == null)
            {
                return HttpNotFound();
            }
            return View(tbllogin);
        }

        // POST: tbllogins/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Uid,BadgeNumber,UserName,pass,endloginTime,persianName,UEnable")] tbllogin tbllogin)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbllogin).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbllogin);
        }

        // GET: tbllogins/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbllogin tbllogin = db.tbllogin.Find(id);
            if (tbllogin == null)
            {
                return HttpNotFound();
            }
            return View(tbllogin);
        }

        // POST: tbllogins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbllogin tbllogin = db.tbllogin.Find(id);
            db.tbllogin.Remove(tbllogin);
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
