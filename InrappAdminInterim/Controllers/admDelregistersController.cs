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
    public class admDelregistersController : Controller
    {
        private DB11Entities db = new DB11Entities();

        // GET: admDelregisters
        public ActionResult Index()
        {
            var admDelregisters = db.admDelregisters.Include(a => a.admRegister);
            return View(admDelregisters.ToList());
        }

        // GET: admDelregisters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            admDelregister admDelregister = db.admDelregisters.Find(id);
            if (admDelregister == null)
            {
                return HttpNotFound();
            }
            return View(admDelregister);
        }

        // GET: admDelregisters/Create
        public ActionResult Create()
        {
            ViewBag.registerid = new SelectList(db.admRegisters, "registerid", "registernamn");
            return View();
        }

        // POST: admDelregisters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "delregisterid,registerid,delregisternamn,beskrivning,kortnamn,inrapporteringsportal,slussmapp,skapaddatum,skapadav,andraddatum,andradav")] admDelregister admDelregister)
        {
            if (ModelState.IsValid)
            {
                db.admDelregisters.Add(admDelregister);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.registerid = new SelectList(db.admRegisters, "registerid", "registernamn", admDelregister.registerid);
            return View(admDelregister);
        }

        // GET: admDelregisters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            admDelregister admDelregister = db.admDelregisters.Find(id);
            if (admDelregister == null)
            {
                return HttpNotFound();
            }
            ViewBag.registerid = new SelectList(db.admRegisters, "registerid", "registernamn", admDelregister.registerid);
            return View(admDelregister);
        }

        // POST: admDelregisters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "delregisterid,registerid,delregisternamn,beskrivning,kortnamn,inrapporteringsportal,slussmapp,skapaddatum,skapadav,andraddatum,andradav")] admDelregister admDelregister)
        {
            if (ModelState.IsValid)
            {
                db.Entry(admDelregister).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.registerid = new SelectList(db.admRegisters, "registerid", "registernamn", admDelregister.registerid);
            return View(admDelregister);
        }

        // GET: admDelregisters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            admDelregister admDelregister = db.admDelregisters.Find(id);
            if (admDelregister == null)
            {
                return HttpNotFound();
            }
            return View(admDelregister);
        }

        // POST: admDelregisters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            admDelregister admDelregister = db.admDelregisters.Find(id);
            db.admDelregisters.Remove(admDelregister);
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
