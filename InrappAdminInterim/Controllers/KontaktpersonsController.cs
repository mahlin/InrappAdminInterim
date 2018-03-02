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
    public class KontaktpersonsController : Controller
    {
        private DB11Entities db = new DB11Entities();

        // GET: Kontaktpersons
        public ActionResult Index()
        {
            var kontaktpersons = db.Kontaktpersons.Include(k => k.Organisation);
            return View(kontaktpersons.ToList());
        }

        // GET: Kontaktpersons/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kontaktperson kontaktperson = db.Kontaktpersons.Find(id);
            if (kontaktperson == null)
            {
                return HttpNotFound();
            }
            return View(kontaktperson);
        }

        // GET: Kontaktpersons/Create
        public ActionResult Create()
        {
            ViewBag.organisationsid = new SelectList(db.Organisations, "organisationsid", "landstingskod");
            return View();
        }

        // POST: Kontaktpersons/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockOutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName,organisationsid,namn,aktivfrom,aktivtom,status,skapaddatum,skapadav,andraddatum,andradav")] Kontaktperson kontaktperson)
        {
            if (ModelState.IsValid)
            {
                db.Kontaktpersons.Add(kontaktperson);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.organisationsid = new SelectList(db.Organisations, "organisationsid", "landstingskod", kontaktperson.organisationsid);
            return View(kontaktperson);
        }

        // GET: Kontaktpersons/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kontaktperson kontaktperson = db.Kontaktpersons.Find(id);
            if (kontaktperson == null)
            {
                return HttpNotFound();
            }
            ViewBag.organisationsid = new SelectList(db.Organisations, "organisationsid", "landstingskod", kontaktperson.organisationsid);
            return View(kontaktperson);
        }

        // POST: Kontaktpersons/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockOutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName,organisationsid,namn,aktivfrom,aktivtom,status,skapaddatum,skapadav,andraddatum,andradav")] Kontaktperson kontaktperson)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kontaktperson).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.organisationsid = new SelectList(db.Organisations, "organisationsid", "landstingskod", kontaktperson.organisationsid);
            return View(kontaktperson);
        }

        // GET: Kontaktpersons/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kontaktperson kontaktperson = db.Kontaktpersons.Find(id);
            if (kontaktperson == null)
            {
                return HttpNotFound();
            }
            return View(kontaktperson);
        }

        // POST: Kontaktpersons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Kontaktperson kontaktperson = db.Kontaktpersons.Find(id);
            db.Kontaktpersons.Remove(kontaktperson);
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
