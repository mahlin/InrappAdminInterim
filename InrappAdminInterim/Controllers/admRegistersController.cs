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
    public class admRegistersController : Controller
    {
        private DB11Entities db = new DB11Entities();

        // GET: admRegisters
        public ActionResult Index()
        {
            return View(db.admRegisters.ToList());
        }

        // GET: admRegisters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            admRegister admRegister = db.admRegisters.Find(id);
            if (admRegister == null)
            {
                return HttpNotFound();
            }
            return View(admRegister);
        }

        // GET: admRegisters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: admRegisters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "registerid,registernamn,beskrivning,kortnamn,inrapporteringsportal,skapaddatum,skapadav,andraddatum,andradav")] admRegister admRegister)
        {
            if (ModelState.IsValid)
            {
                db.admRegisters.Add(admRegister);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(admRegister);
        }

        // GET: admRegisters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            admRegister admRegister = db.admRegisters.Find(id);
            if (admRegister == null)
            {
                return HttpNotFound();
            }
            return View(admRegister);
        }

        // POST: admRegisters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "registerid,registernamn,beskrivning,kortnamn,inrapporteringsportal,skapaddatum,skapadav,andraddatum,andradav")] admRegister admRegister)
        {
            if (ModelState.IsValid)
            {
                db.Entry(admRegister).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(admRegister);
        }

        // GET: admRegisters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            admRegister admRegister = db.admRegisters.Find(id);
            if (admRegister == null)
            {
                return HttpNotFound();
            }
            return View(admRegister);
        }

        // POST: admRegisters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            admRegister admRegister = db.admRegisters.Find(id);
            db.admRegisters.Remove(admRegister);
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
