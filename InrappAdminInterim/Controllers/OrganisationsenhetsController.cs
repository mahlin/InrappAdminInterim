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
    public class OrganisationsenhetsController : Controller
    {
        private DB11Entities db = new DB11Entities();

        // GET: Organisationsenhets
        public ActionResult Index()
        {
            var organisationsenhets = db.Organisationsenhets.Include(o => o.Organisation);
            return View(organisationsenhets.ToList());
        }

        // GET: Organisationsenhets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Organisationsenhet organisationsenhet = db.Organisationsenhets.Find(id);
            if (organisationsenhet == null)
            {
                return HttpNotFound();
            }
            return View(organisationsenhet);
        }

        // GET: Organisationsenhets/Create
        public ActionResult Create()
        {
            ViewBag.organisationsid = new SelectList(db.Organisations, "organisationsid", "landstingskod");
            return View();
        }

        // POST: Organisationsenhets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "organisationsenhetsid,organisationsid,enhetsnamn,enhetskod,aktivfrom,aktivtom,skapaddatum,skapadav,andraddatum,andradav")] Organisationsenhet organisationsenhet)
        {
            if (ModelState.IsValid)
            {
                db.Organisationsenhets.Add(organisationsenhet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.organisationsid = new SelectList(db.Organisations, "organisationsid", "landstingskod", organisationsenhet.organisationsid);
            return View(organisationsenhet);
        }

        // GET: Organisationsenhets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Organisationsenhet organisationsenhet = db.Organisationsenhets.Find(id);
            if (organisationsenhet == null)
            {
                return HttpNotFound();
            }
            ViewBag.organisationsid = new SelectList(db.Organisations, "organisationsid", "landstingskod", organisationsenhet.organisationsid);
            return View(organisationsenhet);
        }

        // POST: Organisationsenhets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "organisationsenhetsid,organisationsid,enhetsnamn,enhetskod,aktivfrom,aktivtom,skapaddatum,skapadav,andraddatum,andradav")] Organisationsenhet organisationsenhet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(organisationsenhet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.organisationsid = new SelectList(db.Organisations, "organisationsid", "landstingskod", organisationsenhet.organisationsid);
            return View(organisationsenhet);
        }

        // GET: Organisationsenhets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Organisationsenhet organisationsenhet = db.Organisationsenhets.Find(id);
            if (organisationsenhet == null)
            {
                return HttpNotFound();
            }
            return View(organisationsenhet);
        }

        // POST: Organisationsenhets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Organisationsenhet organisationsenhet = db.Organisationsenhets.Find(id);
            db.Organisationsenhets.Remove(organisationsenhet);
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
