using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using InrappAdminInterim.Models;

namespace InrappAdminInterim.Controllers
{
    public class admForvantadfilsController : Controller
    {
        private DB11Entities db = new DB11Entities();

        // GET: admForvantadfils
        public ActionResult Index()
        {
            return View(db.admForvantadfils.ToList());
        }

        // GET: admForvantadfils/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            admForvantadfil admForvantadfil = db.admForvantadfils.Find(id);
            if (admForvantadfil == null)
            {
                return HttpNotFound();
            }
            return View(admForvantadfil);
        }

        // GET: admForvantadfils/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: admForvantadfils/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "forvantadfilid,filkravid,foreskriftsid,filmask,regexp,obligatorisk,tom,skapaddatum,skapadav,andraddatum,andradav")] admForvantadfil admForvantadfil)
        {
            if (ModelState.IsValid)
            {
                db.admForvantadfils.Add(admForvantadfil);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(admForvantadfil);
        }

        // GET: admForvantadfils/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            admForvantadfil admForvantadfil = db.admForvantadfils.Find(id);
            if (admForvantadfil == null)
            {
                return HttpNotFound();
            }
            return View(admForvantadfil);
        }

        // POST: admForvantadfils/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "forvantadfilid,filkravid,foreskriftsid,filmask,regexp,obligatorisk,tom,skapaddatum,skapadav,andraddatum,andradav")] admForvantadfil admForvantadfil)
        {
            if (ModelState.IsValid)
            {
                db.Entry(admForvantadfil).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(admForvantadfil);
        }

        // GET: admForvantadfils/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            admForvantadfil admForvantadfil = db.admForvantadfils.Find(id);
            if (admForvantadfil == null)
            {
                return HttpNotFound();
            }
            return View(admForvantadfil);
        }

        // POST: admForvantadfils/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            admForvantadfil admForvantadfil = db.admForvantadfils.Find(id);
            db.admForvantadfils.Remove(admForvantadfil);
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
