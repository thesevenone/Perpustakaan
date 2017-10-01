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
    public class PinjamTabelsController : Controller
    {
        private PerpustakaanDBEntities db = new PerpustakaanDBEntities();

        // GET: PinjamTabels
        public ActionResult Index()
        {
            var pinjamTabel = db.PinjamTabel.Include(p => p.BukuTabel);
            return View(pinjamTabel.ToList());
        }

        // GET: PinjamTabels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PinjamTabel pinjamTabel = db.PinjamTabel.Find(id);
            if (pinjamTabel == null)
            {
                return HttpNotFound();
            }
            return View(pinjamTabel);
        }

        // GET: PinjamTabels/Create
        public ActionResult Create()
        {
            ViewBag.ISBN = new SelectList(db.BukuTabel, "ISBN", "NamaPengarang");
            return View();
        }

        // POST: PinjamTabels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,WaktuPinjam,WaktuKembali,ISBN")] PinjamTabel pinjamTabel)
        {
            if (ModelState.IsValid)
            {
                db.PinjamTabel.Add(pinjamTabel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ISBN = new SelectList(db.BukuTabel, "ISBN", "NamaPengarang", pinjamTabel.ISBN);
            return View(pinjamTabel);
        }

        // GET: PinjamTabels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PinjamTabel pinjamTabel = db.PinjamTabel.Find(id);
            if (pinjamTabel == null)
            {
                return HttpNotFound();
            }
            ViewBag.ISBN = new SelectList(db.BukuTabel, "ISBN", "NamaPengarang", pinjamTabel.ISBN);
            return View(pinjamTabel);
        }

        // POST: PinjamTabels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,WaktuPinjam,WaktuKembali,ISBN")] PinjamTabel pinjamTabel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pinjamTabel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ISBN = new SelectList(db.BukuTabel, "ISBN", "NamaPengarang", pinjamTabel.ISBN);
            return View(pinjamTabel);
        }

        // GET: PinjamTabels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PinjamTabel pinjamTabel = db.PinjamTabel.Find(id);
            if (pinjamTabel == null)
            {
                return HttpNotFound();
            }
            return View(pinjamTabel);
        }

        // POST: PinjamTabels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PinjamTabel pinjamTabel = db.PinjamTabel.Find(id);
            db.PinjamTabel.Remove(pinjamTabel);
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
