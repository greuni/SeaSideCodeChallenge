using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SeaSideCodeChallenge.Models;

namespace SeaSideCodeChallenge.Controllers
{
    /// <summary>
    /// Controller class for Customer Page
    /// I am using the MVC scaffolding to auto generate CRUD operations
    /// </summary>
    public class CustomerController : Controller
    {
        private CustomerDBContext db = new CustomerDBContext();

        //
        // GET: /Customer/

        public ActionResult Index(int pageNo = 0)
        {
            const int pageSize = 5;
            int totalCount = db.Customers.Count();
            var itemsToDisplay = db.Customers.OrderByDescending(model => model.lastName).Skip(pageNo * pageSize).Take(pageSize).ToList();
            this.ViewBag.maxPage = (totalCount / pageSize) - (totalCount % pageSize == 0 ? 1 : 0);
            this.ViewBag.pageNo = pageNo;
            return View(itemsToDisplay);
        }

        //
        // GET: /Customer/Details/5

        public ActionResult Details(int id = 0)
        {
            CustomerModel customermodel = db.Customers.Find(id);
            if (customermodel == null)
            {
                return HttpNotFound();
            }
            return View(customermodel);
        }

        //
        // GET: /Customer/Create
        /// <summary>
        /// Navigates the user to a customer create page.
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Customer/Create
        /// <summary>
        /// Navigates the customer to the Customer Listing page once
        /// the user saves the new customer he/she wants to create
        /// </summary>
        /// <param name="customermodel"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CustomerModel customermodel)
        {
            if (ModelState.IsValid)
            {
                db.Customers.Add(customermodel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customermodel);
        }

        //
        // GET: /Customer/Edit/5

        public ActionResult Edit(int id = 0)
        {
            CustomerModel customermodel = db.Customers.Find(id);
            if (customermodel == null)
            {
                return HttpNotFound();
            }
            return View(customermodel);
        }

        //
        // POST: /Customer/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CustomerModel customermodel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customermodel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customermodel);
        }

        //
        // GET: /Customer/Delete/5

        public ActionResult Delete(int id = 0)
        {
            CustomerModel customermodel = db.Customers.Find(id);
            if (customermodel == null)
            {
                return HttpNotFound();
            }
            return View(customermodel);
        }

        //
        // POST: /Customer/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CustomerModel customermodel = db.Customers.Find(id);
            db.Customers.Remove(customermodel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}