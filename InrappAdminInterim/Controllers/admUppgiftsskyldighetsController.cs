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
    public class admUppgiftsskyldighetsController : Controller
    {
        private DB11Entities db = new DB11Entities();

        // GET: admUppgiftsskyldighets
        public ActionResult Index()
        {
            var admUppgiftsskyldighets = db.admUppgiftsskyldighets.Include(a => a.admDelregister).Include(a => a.Organisation);
            return View(admUppgiftsskyldighets.ToList());
        }

        // GET: admUppgiftsskyldighets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            admUppgiftsskyldighet admUppgiftsskyldighet = db.admUppgiftsskyldighets.Find(id);
            if (admUppgiftsskyldighet == null)
            {
                return HttpNotFound();
            }
            return View(admUppgiftsskyldighet);
        }

        // GET: admUppgiftsskyldighets/Create
        public ActionResult Create()
        {
            ViewBag.delregisterid = new SelectList(db.admDelregisters, "delregisterid", "delregisternamn");
            ViewBag.organisationsid = new SelectList(db.Organisations, "organisationsid", "landstingskod");
            return View();
        }

        // POST: admUppgiftsskyldighets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "uppgiftsskyldighetid,organisationsid,delregisterid,skyldigfrom,skyldigtom,rapporterarperenhet,skapaddatum,skapadav,andraddatum,andradav")] admUppgiftsskyldighet admUppgiftsskyldighet)
        {
            if (ModelState.IsValid)
            {
                db.admUppgiftsskyldighets.Add(admUppgiftsskyldighet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.delregisterid = new SelectList(db.admDelregisters, "delregisterid", "delregisternamn", admUppgiftsskyldighet.delregisterid);
            ViewBag.organisationsid = new SelectList(db.Organisations, "organisationsid", "landstingskod", admUppgiftsskyldighet.organisationsid);
            return View(admUppgiftsskyldighet);
        }

        // GET: admUppgiftsskyldighets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            admUppgiftsskyldighet admUppgiftsskyldighet = db.admUppgiftsskyldighets.Find(id);
            if (admUppgiftsskyldighet == null)
            {
                return HttpNotFound();
            }
            ViewBag.delregisterid = new SelectList(db.admDelregisters, "delregisterid", "delregisternamn", admUppgiftsskyldighet.delregisterid);
            ViewBag.organisationsid = new SelectList(db.Organisations, "organisationsid", "landstingskod", admUppgiftsskyldighet.organisationsid);
            return View(admUppgiftsskyldighet);
        }

        // POST: admUppgiftsskyldighets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "uppgiftsskyldighetid,organisationsid,delregisterid,skyldigfrom,skyldigtom,rapporterarperenhet,skapaddatum,skapadav,andraddatum,andradav")] admUppgiftsskyldighet admUppgiftsskyldighet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(admUppgiftsskyldighet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.delregisterid = new SelectList(db.admDelregisters, "delregisterid", "delregisternamn", admUppgiftsskyldighet.delregisterid);
            ViewBag.organisationsid = new SelectList(db.Organisations, "organisationsid", "landstingskod", admUppgiftsskyldighet.organisationsid);
            return View(admUppgiftsskyldighet);
        }

        // GET: admUppgiftsskyldighets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            admUppgiftsskyldighet admUppgiftsskyldighet = db.admUppgiftsskyldighets.Find(id);
            if (admUppgiftsskyldighet == null)
            {
                return HttpNotFound();
            }
            return View(admUppgiftsskyldighet);
        }

        // POST: admUppgiftsskyldighets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            admUppgiftsskyldighet admUppgiftsskyldighet = db.admUppgiftsskyldighets.Find(id);
            db.admUppgiftsskyldighets.Remove(admUppgiftsskyldighet);
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
