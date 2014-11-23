using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DapperExample.Dapper;

namespace DapperExample.Controllers
{
    public class EmployeeController : Controller
    {
        private IEmployeeDashBoard _dashboard = new EmployeeDashBoard();
        //
        // GET: /Employee/

        public ActionResult Index()
        {
            return View(_dashboard.GetAll());
        }

        //
        // GET: /Employee/Details/5

        public ActionResult Details(int? id)
        {

            return View(_dashboard.Find(id));
        }

        public ActionResult Search(string SearchString)
        {

            return View(_dashboard.Find(SearchString));
        }
        //
        // GET: /Employee/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Employee/Create

        [HttpPost]
        public ActionResult Create([Bind(Include = "EmpName,EmpScore")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                _dashboard.Add(employee);
                return RedirectToAction("Index");
            }

            return View(employee);
        }

        //
        // GET: /Employee/Edit/5

        public ActionResult Edit(int id)
        {
            return View(_dashboard.Find(id));
        }

        // POST: /User/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        public ActionResult Edit([Bind(Include = "EmpID,EmpName,EmpScore")] Employee employee, int id)
        {
            if (ModelState.IsValid)
            {
                _dashboard.Update(employee);
            }
            return View(employee);
        }

        //
        // GET: /Employee/Delete/5

        public ActionResult Delete(int id)
        {
            return View(_dashboard.Find(id));
        }

        // POST: /Employee/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                _dashboard.Remove(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
