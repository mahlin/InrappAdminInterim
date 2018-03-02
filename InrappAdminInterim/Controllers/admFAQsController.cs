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
    public class admFAQsController : Controller
    {
        private DB11Entities db = new DB11Entities();

        // GET: admFAQs
        public ActionResult Index()
        {
            var admFAQs = db.admFAQs.Include(a => a.admFAQKategori).Include(a => a.admRegister);
            return View(admFAQs.ToList());
        }

        // GET: admFAQs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            admFAQ admFAQ = db.admFAQs.Find(id);
            if (admFAQ == null)
            {
                return HttpNotFound();
            }
            return View(admFAQ);
        }

        // GET: admFAQs/Create
        public ActionResult Create()
        {
            ViewBag.faqkatergoriid = new SelectList(db.admFAQKategoris, "faqkatergoriid", "kategori");
            ViewBag.registerid = new SelectList(db.admRegisters, "registerid", "registernamn");
            return View();
        }

        // POST: admFAQs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "faqid,registerid,faqkatergoriid,fraga,svar,skapaddatum,skapadav,andraddatum,andradav")] admFAQ admFAQ)
        {
            if (ModelState.IsValid)
            {
                db.admFAQs.Add(admFAQ);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.faqkatergoriid = new SelectList(db.admFAQKategoris, "faqkatergoriid", "kategori", admFAQ.faqkatergoriid);
            ViewBag.registerid = new SelectList(db.admRegisters, "registerid", "registernamn", admFAQ.registerid);
            return View(admFAQ);
        }

        // GET: admFAQs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            admFAQ admFAQ = db.admFAQs.Find(id);
            if (admFAQ == null)
            {
                return HttpNotFound();
            }
            ViewBag.faqkatergoriid = new SelectList(db.admFAQKategoris, "faqkatergoriid", "kategori", admFAQ.faqkatergoriid);
            ViewBag.registerid = new SelectList(db.admRegisters, "registerid", "registernamn", admFAQ.registerid);
            return View(admFAQ);
        }

        // POST: admFAQs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "faqid,registerid,faqkatergoriid,fraga,svar,skapaddatum,skapadav,andraddatum,andradav")] admFAQ admFAQ)
        {
            if (ModelState.IsValid)
            {
                db.Entry(admFAQ).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.faqkatergoriid = new SelectList(db.admFAQKategoris, "faqkatergoriid", "kategori", admFAQ.faqkatergoriid);
            ViewBag.registerid = new SelectList(db.admRegisters, "registerid", "registernamn", admFAQ.registerid);
            return View(admFAQ);
        }

        // GET: admFAQs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            admFAQ admFAQ = db.admFAQs.Find(id);
            if (admFAQ == null)
            {
                return HttpNotFound();
            }
            return View(admFAQ);
        }

        // POST: admFAQs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            admFAQ admFAQ = db.admFAQs.Find(id);
            db.admFAQs.Remove(admFAQ);
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
