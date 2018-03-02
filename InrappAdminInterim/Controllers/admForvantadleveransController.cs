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
    public class admForvantadleveransController : Controller
    {
        private DB11Entities db = new DB11Entities();

        // GET: admForvantadleverans
        public ActionResult Index()
        {
            var admForvantadleverans = db.admForvantadleverans.Include(a => a.admDelregister);
            return View(admForvantadleverans.ToList());
        }

        // GET: admForvantadleverans/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            admForvantadleveran admForvantadleveran = db.admForvantadleverans.Find(id);
            if (admForvantadleveran == null)
            {
                return HttpNotFound();
            }
            return View(admForvantadleveran);
        }

        // GET: admForvantadleverans/Create
        public ActionResult Create()
        {
            ViewBag.delregisterid = new SelectList(db.admDelregisters, "delregisterid", "delregisternamn");
            return View();
        }

        // POST: admForvantadleverans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "forvantadleveransid,delregisterid,filkravid,period,uppgiftsstart,uppgiftsslut,rapporteringsstart,rapporteringsslut,rapporteringsenast,paminnelse1,paminnelse2,paminnelse3,skapaddatum,skapadav,andraddatum,andradav")] admForvantadleveran admForvantadleveran)
        {
            if (ModelState.IsValid)
            {
                db.admForvantadleverans.Add(admForvantadleveran);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.delregisterid = new SelectList(db.admDelregisters, "delregisterid", "delregisternamn", admForvantadleveran.delregisterid);
            return View(admForvantadleveran);
        }

        // GET: admForvantadleverans/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            admForvantadleveran admForvantadleveran = db.admForvantadleverans.Find(id);
            if (admForvantadleveran == null)
            {
                return HttpNotFound();
            }
            ViewBag.delregisterid = new SelectList(db.admDelregisters, "delregisterid", "delregisternamn", admForvantadleveran.delregisterid);
            return View(admForvantadleveran);
        }

        // POST: admForvantadleverans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "forvantadleveransid,delregisterid,filkravid,period,uppgiftsstart,uppgiftsslut,rapporteringsstart,rapporteringsslut,rapporteringsenast,paminnelse1,paminnelse2,paminnelse3,skapaddatum,skapadav,andraddatum,andradav")] admForvantadleveran admForvantadleveran)
        {
            if (ModelState.IsValid)
            {
                db.Entry(admForvantadleveran).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.delregisterid = new SelectList(db.admDelregisters, "delregisterid", "delregisternamn", admForvantadleveran.delregisterid);
            return View(admForvantadleveran);
        }

        // GET: admForvantadleverans/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            admForvantadleveran admForvantadleveran = db.admForvantadleverans.Find(id);
            if (admForvantadleveran == null)
            {
                return HttpNotFound();
            }
            return View(admForvantadleveran);
        }

        // POST: admForvantadleverans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            admForvantadleveran admForvantadleveran = db.admForvantadleverans.Find(id);
            db.admForvantadleverans.Remove(admForvantadleveran);
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
