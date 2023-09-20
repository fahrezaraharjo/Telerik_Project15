using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System.Collections.Generic;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Telerik_Project15.Models;


namespace Telerik_Project15.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ApplicationDbContext db = new ApplicationDbContext("name=ApplicationDbContext");

        // GET: Customer
        public ActionResult Index()
        {
            return View(db.Customers.ToList());
        }

        [HttpGet]
        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            // Retrieve and return the data for the Kendo Grid
            var customers = db.Customers.ToList(); // You might want to customize this query
            return Json(customers.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        // POST: Customer/Create
        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                // Insert the new customer into the database
                db.Customers.Add(customer);
                db.SaveChanges();

                // Return a success response
                return Json(new { Success = true });
            }

            // If ModelState is not valid, return validation errors
            var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
            return Json(new { Success = false, Errors = errors });
        }

        // POST: Customer/Update
        [HttpPost]
        public ActionResult Update(Customer customer)
        {
            if (ModelState.IsValid)
            {
                // Update customer in the database (e.g., using Entity Framework)
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
            }

            return Json(new[] { customer }.ToDataSourceResult(new DataSourceRequest(), ModelState));
        }

        // POST: Customer/Delete
        [HttpPost]
        public JsonResult OnPostDestroy([DataSourceRequest] DataSourceRequest request, int id)
        {
            // Find the customer to delete by ID (e.g., using Entity Framework)
            var customer = db.Customers.Find(id);
            if (customer != null)
            {
                // Remove customer from the database
                db.Customers.Remove(customer);
                db.SaveChanges();
            }

            return Json(new[] { customer }.ToDataSourceResult(request, ModelState));
        }
    }

}