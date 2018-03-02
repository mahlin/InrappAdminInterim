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
    public class admInformationsController : Controller
    {
        private DB11Entities db = new DB11Entities();

        // GET: admInformations
        public ActionResult Index()
        {
            return View(db.admInformations.ToList());
        }

        // GET: admInformations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            admInformation admInformation = db.admInformations.Find(id);
            if (admInformation == null)
            {
                return HttpNotFound();
            }
            return View(admInformation);
        }

        // GET: admInformations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: admInformations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "informationsid,informationstyp,text,skapaddatum,skapadav,andraddatum,andradav")] admInformation admInformation)
        {
            if (ModelState.IsValid)
            {
                db.admInformations.Add(admInformation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(admInformation);
        }

        // GET: admInformations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            admInformation admInformation = db.admInformations.Find(id);
            if (admInformation == null)
            {
                return HttpNotFound();
            }
            return View(admInformation);
        }

        // POST: admInformations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "informationsid,informationstyp,text,skapaddatum,skapadav,andraddatum,andradav")] admInformation admInformation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(admInformation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(admInformation);
        }

        // GET: admInformations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            admInformation admInformation = db.admInformations.Find(id);
            if (admInformation == null)
            {
                return HttpNotFound();
            }
            return View(admInformation);
        }

        // POST: admInformations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            admInformation admInformation = db.admInformations.Find(id);
            db.admInformations.Remove(admInformation);
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
