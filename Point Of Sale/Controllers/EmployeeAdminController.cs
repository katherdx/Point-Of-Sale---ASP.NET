﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Point_Of_Sale;

namespace Point_Of_Sale.Controllers
{
    public class EmployeeAdminController : Controller
    {
        private POS_WebEntities db = new POS_WebEntities();

        // GET: EmployeeAdmin
        public ActionResult Index()
        {
            var employeeAdmins = db.EmployeeAdmins.Include(e => e.Employee);
            return View(employeeAdmins.ToList());
        }

        // GET: EmployeeAdmin/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeAdmin employeeAdmin = db.EmployeeAdmins.Find(id);
            if (employeeAdmin == null)
            {
                return HttpNotFound();
            }
            return View(employeeAdmin);
        }

        // GET: EmployeeAdmin/Create
        public ActionResult Create()
        {
            ViewBag.EmployeeID = new SelectList(db.Employees, "ID", "EmployeeName");
            return View();
        }

        // POST: EmployeeAdmin/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeID")] EmployeeAdmin employeeAdmin)
        {
            if (ModelState.IsValid)
            {
                db.EmployeeAdmins.Add(employeeAdmin);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmployeeID = new SelectList(db.Employees, "ID", "EmployeeName", employeeAdmin.EmployeeID);
            return View(employeeAdmin);
        }

        // GET: EmployeeAdmin/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeAdmin employeeAdmin = db.EmployeeAdmins.Find(id);
            if (employeeAdmin == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeID = new SelectList(db.Employees, "ID", "EmployeeName", employeeAdmin.EmployeeID);
            return View(employeeAdmin);
        }

        // POST: EmployeeAdmin/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeID")] EmployeeAdmin employeeAdmin)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employeeAdmin).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeID = new SelectList(db.Employees, "ID", "EmployeeName", employeeAdmin.EmployeeID);
            return View(employeeAdmin);
        }

        // GET: EmployeeAdmin/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeAdmin employeeAdmin = db.EmployeeAdmins.Find(id);
            if (employeeAdmin == null)
            {
                return HttpNotFound();
            }
            return View(employeeAdmin);
        }

        // POST: EmployeeAdmin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmployeeAdmin employeeAdmin = db.EmployeeAdmins.Find(id);
            db.EmployeeAdmins.Remove(employeeAdmin);
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