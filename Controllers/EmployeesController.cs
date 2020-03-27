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
    public class EmployeesController : Controller
    {
        private MIS4200Context db = new MIS4200Context();

        // GET: Employees
        public ActionResult Index(string searchString)
        {
            //var testusers = from u in db.Employees select u;
            //if (!String.IsNullOrEmpty(searchString))
            //{
            //    testusers = testusers.Where(u => u.lastname.Contains(searchString)
            //   || u.firstName.Contains(searchString));
            //   // if here, users were found so view them
            //   return View(testusers.ToList());
            //}
            //   return View(db.Employees.ToList());
            var empSearch = from c in db.Employees select c;
            string[] employeeNames;
            if (!String.IsNullOrEmpty(searchString))
            {
                employeeNames = searchString.Split(' '); // split the string on spaces
                if (employeeNames.Count() == 1) // there is only one string so it could be
                                                // either the first or last name
                {
                    empSearch = empSearch.Where(c => c.employeeFirstName.Contains(searchString) || c.employeeLastName.Contains(searchString)).OrderBy(c => c.employeeFirstName);
                }
                else //if you get here there were at least two strings so extract them and test
                {
                    string s1 = employeeNames[0];
                    string s2 = employeeNames[1];
                    empSearch = empSearch.Where(c => c.employeeFirstName.Contains(s2) && c.employeeLastName.Contains(s1)).OrderBy(c => c.employeeFirstName); // note that this uses &&, not ||
                }
                return View(empSearch.ToList());
            }


            return View(db.Employees.ToList());
        }

        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "employeeId,employeeFirstName,employeeLastName,businessUnit,hireDateTime,employeeTitle")] Employee employee)
        {3
            if (ModelState.IsValid)
            {
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employee);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "employeeId,employeeFirstName,employeeLastName,businessUnit,hireDateTime,employeeTitle")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
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
