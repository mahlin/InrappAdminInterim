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
    public class admFAQKategorisController : Controller
    {
        private DB11Entities db = new DB11Entities();

        // GET: admFAQKategoris
        public ActionResult Index()
        {
            return View(db.admFAQKategoris.ToList());
        }

        // GET: admFAQKategoris/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            admFAQKategori admFAQKategori = db.admFAQKategoris.Find(id);
            if (admFAQKategori == null)
            {
                return HttpNotFound();
            }
            return View(admFAQKategori);
        }

        // GET: admFAQKategoris/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: admFAQKategoris/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "faqkategoriid,kategori,skapaddatum,skapadav,andraddatum,andradav")] admFAQKategori admFAQKategori)
        {
            if (ModelState.IsValid)
            {
                db.admFAQKategoris.Add(admFAQKategori);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(admFAQKategori);
        }

        // GET: admFAQKategoris/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            admFAQKategori admFAQKategori = db.admFAQKategoris.Find(id);
            if (admFAQKategori == null)
            {
                return HttpNotFound();
            }
            return View(admFAQKategori);
        }

        // POST: admFAQKategoris/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "faqkategoriid,kategori,skapaddatum,skapadav,andraddatum,andradav")] admFAQKategori admFAQKategori)
        {
            if (ModelState.IsValid)
            {
                db.Entry(admFAQKategori).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(admFAQKategori);
        }

        // GET: admFAQKategoris/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            admFAQKategori admFAQKategori = db.admFAQKategoris.Find(id);
            if (admFAQKategori == null)
            {
                return HttpNotFound();
            }
            return View(admFAQKategori);
        }

        // POST: admFAQKategoris/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            admFAQKategori admFAQKategori = db.admFAQKategoris.Find(id);
            db.admFAQKategoris.Remove(admFAQKategori);
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
