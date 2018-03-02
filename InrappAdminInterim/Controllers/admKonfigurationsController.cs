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
    public class admKonfigurationsController : Controller
    {
        private DB11Entities db = new DB11Entities();

        // GET: admKonfigurations
        public ActionResult Index()
        {
            return View(db.admKonfigurations.ToList());
        }

        // GET: admKonfigurations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            admKonfiguration admKonfiguration = db.admKonfigurations.Find(id);
            if (admKonfiguration == null)
            {
                return HttpNotFound();
            }
            return View(admKonfiguration);
        }

        // GET: admKonfigurations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: admKonfigurations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "konfigurationsid,typ,varde,skapaddatum,skapadav,andraddatum,andradav")] admKonfiguration admKonfiguration)
        {
            if (ModelState.IsValid)
            {
                db.admKonfigurations.Add(admKonfiguration);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(admKonfiguration);
        }

        // GET: admKonfigurations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            admKonfiguration admKonfiguration = db.admKonfigurations.Find(id);
            if (admKonfiguration == null)
            {
                return HttpNotFound();
            }
            return View(admKonfiguration);
        }

        // POST: admKonfigurations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "konfigurationsid,typ,varde,skapaddatum,skapadav,andraddatum,andradav")] admKonfiguration admKonfiguration)
        {
            if (ModelState.IsValid)
            {
                db.Entry(admKonfiguration).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(admKonfiguration);
        }

        // GET: admKonfigurations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            admKonfiguration admKonfiguration = db.admKonfigurations.Find(id);
            if (admKonfiguration == null)
            {
                return HttpNotFound();
            }
            return View(admKonfiguration);
        }

        // POST: admKonfigurations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            admKonfiguration admKonfiguration = db.admKonfigurations.Find(id);
            db.admKonfigurations.Remove(admKonfiguration);
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
