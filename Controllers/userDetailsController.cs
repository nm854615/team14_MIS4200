﻿using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using team14_MIS4200.DAL;
using team14_MIS4200.Models;

namespace team14_MIS4200.Controllers
{
    public class userDetailsController : Controller
    {
        private MIS4200Context db = new MIS4200Context();

        // GET: userDetails
        public ActionResult Index(string searchString)
        {
            var empSearch = from o in db.userDetails select o;
            string[] empNames; // declare the array to hold pieces of the string
            if (!String.IsNullOrEmpty(searchString))
            {
                empNames = searchString.Split(' '); // split the string on spaces
                if (empNames.Count() == 1) // there is only one string so it could be
                                            // either the first or last name
                {
                    empSearch = empSearch.Where(c => c.firstName.Contains(searchString) ||
                   c.lastName.Contains(searchString)).OrderBy(c => c.lastName);
                }
                else //if you get here there were at least two strings so extract them and test
                {
                    string s1 = empNames[0];
                    string s2 = empNames[1];
                    empSearch = empSearch.Where(c => c.firstName.Contains(s1) &&
                   c.lastName.Contains(s2)).OrderBy(c => c.firstName); // note that this uses &&, not ||
                }
                return View(empSearch.ToList());
            }


            if (User.Identity.IsAuthenticated)
            {
                return View(db.userDetails.ToList());
            }
            else
            {
                return View("NotAuthenticated");
            }
        }

        // GET: userDetails/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            userDetails userDetails = db.userDetails.Find(id);
            if (userDetails == null)
            {
                return HttpNotFound();
            }
            return View(userDetails);
        }

        // GET: userDetails/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: userDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Email,firstName,lastName,birthday,group,title,hireDateTime")] userDetails userDetails)
        {
            if (ModelState.IsValid)
            {
                // userDetails.ID = Guid.NewGuid(); // original new Guid
                Guid memberID; // create a variable to hold the Guid
                Guid.TryParse(User.Identity.GetUserId(), out memberID);
                userDetails.ID = memberID;
                db.userDetails.Add(userDetails);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userDetails);
        }

        // GET: userDetails/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            userDetails userDetails = db.userDetails.Find(id);
            if (userDetails == null)
            {
                return HttpNotFound();
            }
            return View(userDetails);
        }

        // POST: userDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Email,firstName,lastName,birthday,group,title,hireDateTime")] userDetails userDetails)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userDetails).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userDetails);
        }

        // GET: userDetails/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            userDetails userDetails = db.userDetails.Find(id);
            if (userDetails == null)
            {
                return HttpNotFound();
            }
            return View(userDetails);
        }

        // POST: userDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            userDetails userDetails = db.userDetails.Find(id);
            db.userDetails.Remove(userDetails);
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
