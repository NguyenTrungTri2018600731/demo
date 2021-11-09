﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using _11_9.Models;

namespace _11_9.Controllers
{
    public class employeesController : Controller
    {
        private AnhLam db = new AnhLam();

        // GET: employees
        public ActionResult Index()
        {
            var employees = db.employees.Include(e => e.department).Include(e => e.employee1).Include(e => e.job);
            return View(employees.ToList());
        }

        // GET: employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            employee employee = db.employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: employees/Create
        public ActionResult Create()
        {
            ViewBag.department_id = new SelectList(db.departments, "department_id", "department_name");
            ViewBag.manager_id = new SelectList(db.employees, "employee_id", "first_name");
            ViewBag.job_id = new SelectList(db.jobs, "job_id", "job_title");
            return View();
        }

        // POST: employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "employee_id,first_name,last_name,email,phone_number,hire_date,job_id,salary,manager_id,department_id")] employee employee)
        {
            if (ModelState.IsValid)
            {
                db.employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.department_id = new SelectList(db.departments, "department_id", "department_name", employee.department_id);
            ViewBag.manager_id = new SelectList(db.employees, "employee_id", "first_name", employee.manager_id);
            ViewBag.job_id = new SelectList(db.jobs, "job_id", "job_title", employee.job_id);
            return View(employee);
        }

        // GET: employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            employee employee = db.employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.department_id = new SelectList(db.departments, "department_id", "department_name", employee.department_id);
            ViewBag.manager_id = new SelectList(db.employees, "employee_id", "first_name", employee.manager_id);
            ViewBag.job_id = new SelectList(db.jobs, "job_id", "job_title", employee.job_id);
            return View(employee);
        }

        // POST: employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "employee_id,first_name,last_name,email,phone_number,hire_date,job_id,salary,manager_id,department_id")] employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.department_id = new SelectList(db.departments, "department_id", "department_name", employee.department_id);
            ViewBag.manager_id = new SelectList(db.employees, "employee_id", "first_name", employee.manager_id);
            ViewBag.job_id = new SelectList(db.jobs, "job_id", "job_title", employee.job_id);
            return View(employee);
        }

        // GET: employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            employee employee = db.employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            employee employee = db.employees.Find(id);
            db.employees.Remove(employee);
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
