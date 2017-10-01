using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Perpustakaan.Models;

namespace Perpustakaan.Controllers
{
    public class BukuTabelsController : Controller
    {
        private PerpustakaanDBEntities db = new PerpustakaanDBEntities();

        // GET: BukuTabels
        public ActionResult Index()
        {
            return View(db.BukuTabel.ToList());
        }

        // GET: BukuTabels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BukuTabel bukuTabel = db.BukuTabel.Find(id);
            if (bukuTabel == null)
            {
                return HttpNotFound();
            }
            return View(bukuTabel);
        }

        // GET: BukuTabels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BukuTabels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ISBN,NamaPengarang,JudulBuku,Tersedia")] BukuTabel bukuTabel)
        {
            if (ModelState.IsValid)
            {
                db.BukuTabel.Add(bukuTabel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bukuTabel);
        }

        // GET: BukuTabels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BukuTabel bukuTabel = db.BukuTabel.Find(id);
            if (bukuTabel == null)
            {
                return HttpNotFound();
            }
            return View(bukuTabel);
        }

        // POST: BukuTabels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ISBN,NamaPengarang,JudulBuku,Tersedia")] BukuTabel bukuTabel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bukuTabel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bukuTabel);
        }

        // GET: BukuTabels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BukuTabel bukuTabel = db.BukuTabel.Find(id);
            if (bukuTabel == null)
            {
                return HttpNotFound();
            }
            return View(bukuTabel);
        }

        // POST: BukuTabels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BukuTabel bukuTabel = db.BukuTabel.Find(id);
            db.BukuTabel.Remove(bukuTabel);
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
