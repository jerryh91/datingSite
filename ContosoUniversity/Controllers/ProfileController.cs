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
using System.Collections;
using System.Diagnostics;

namespace ContosoUniversity.Controllers
{
    public class ProfileController : Controller
    {
        private DatingSiteContext db = new DatingSiteContext();

        // GET: Profiles
        //List of all profiles
        public ActionResult Index()
        {
            return View(db.ProfileMetas.ToList());
        }

        // GET: Profiles/Details/5
        public ActionResult Details(int? id)
        {
            //Verify if User has allowed url to be accessed while logged out
            //If yes: continue execution
            //if else: only if user has logged in can execute

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProfileDetail profile = db.ProfileDetails.Find(id);

            if (profile == null)
            {
                return HttpNotFound();
            }
            return View(profile);
        }

        // GET: Profiles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Profiles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Register register)
        {
            //TODO: Research ModelState
            //NOTE: ModelState is Invalid before "Submit"/POST
            if (ModelState.IsValid)
            {

                //Add 1 ProfileMeta row and 1 linked ProfileDetail row
                //ProfileMeta profileMeta = new ProfileMeta();
                ////profileMeta.ID = register.ProfileMeta_.ID;
                //profileMeta.Username = register.ProfileMeta_.Username;
                //profileMeta.password = register.ProfileMeta_.password;
                
                //ProfileDetail profileDetail = new ProfileDetail();
                ////profileDetail.ID = register.ProfileDetail_.ID;

                ////How to assign FK?
                //profileDetail.ProfileMetaID = register.ProfileDetail_.ID;
                //profileDetail.UserName = register.ProfileDetail_.UserName;
                //profileDetail.Age = register.ProfileDetail_.Age;
                //profileDetail.Location = register.ProfileDetail_.Location;
                //How to assign nav property?
                //profileDetail.ProfileMeta = profileMeta;
                //profileDetail.Gender = register.ProfileDetail_.UserName;
                //profileDetail.Age = register.ProfileDetail_.Age;
                //profileDetail.Location = register.ProfileDetail_.Location;

                //How to assign nav property?
                //profileMeta.ProfileDetail = profileDetail;
                Debug.WriteLine(register.ProfileMeta_.password);
                Debug.WriteLine(register.ProfileMeta_.ID);
                Debug.WriteLine(register.ProfileDetail_.ProfileMetaID);
                db.ProfileMetas.Add(register.ProfileMeta_);
                
                db.ProfileDetails.Add(register.ProfileDetail_);

                //db.ProfileDetails.Add(ProfileDetail_);

                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(register);

        }

        // GET: Profiles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProfileDetail profile = db.ProfileDetails.Find(id);
            if (profile == null)
            {
                return HttpNotFound();
            }
            return View(profile);
        }

        // POST: Profiles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,UserName,Age,Location,Gender")] ProfileDetail profile)
        {
            if (ModelState.IsValid)
            {
                db.Entry(profile).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(profile);
        }

        // GET: Profiles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProfileDetail profile = db.ProfileDetails.Find(id);
            if (profile == null)
            {
                return HttpNotFound();
            }
            return View(profile);
        }

        // POST: ProfileDetail/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProfileDetail profile = db.ProfileDetails.Find(id);
            db.ProfileDetails.Remove(profile);
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
