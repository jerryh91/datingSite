using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ContosoUniversity.DAL;
using ContosoUniversity.Models;

namespace ContosoUniversity.Controllers
{
    public class LoginController : Controller
    {
        private DatingSiteContext db = new DatingSiteContext();

        // GET: Login
        public ActionResult Index()
        {
            var profileMetas = db.ProfileMetas.Include(p => p.ProfileDetail);
            return View(profileMetas.ToList());
        }

        // GET: Login/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProfileMeta profileMeta = db.ProfileMetas.Find(id);
            if (profileMeta == null)
            {
                return HttpNotFound();
            }
            return View(profileMeta);
        }

        // GET: Login/Create
        public ActionResult Create()
        {
            ViewBag.ID = new SelectList(db.ProfileDetails, "ID", "UserName");
            return View();
        }

        // POST: Login/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Username,password,ProfileDetailID")] ProfileMeta profileMeta)
        {
            if (ModelState.IsValid)
            {
                db.ProfileMetas.Add(profileMeta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID = new SelectList(db.ProfileDetails, "ID", "UserName", profileMeta.ID);
            return View(profileMeta);
        }

        // GET: Login/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProfileMeta profileMeta = db.ProfileMetas.Find(id);
            if (profileMeta == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID = new SelectList(db.ProfileDetails, "ID", "UserName", profileMeta.ID);
            return View(profileMeta);
        }

        // POST: Login/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Username,password,ProfileDetailID")] ProfileMeta profileMeta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(profileMeta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID = new SelectList(db.ProfileDetails, "ID", "UserName", profileMeta.ID);
            return View(profileMeta);
        }

        // GET: Login/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProfileMeta profileMeta = db.ProfileMetas.Find(id);
            if (profileMeta == null)
            {
                return HttpNotFound();
            }
            return View(profileMeta);
        }

        // POST: Login/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProfileMeta profileMeta = db.ProfileMetas.Find(id);
            db.ProfileMetas.Remove(profileMeta);
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
