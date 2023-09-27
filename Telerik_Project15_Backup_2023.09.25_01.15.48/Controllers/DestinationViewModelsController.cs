using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Telerik_Project15.Models;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;

namespace Telerik_Project15.Controllers
{
    public class DestinationViewModelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Destination
        public ActionResult Index()
        {
            return View();
        }

        // Action to handle reading data for the ListView
        public ActionResult Grouping_Read([DataSourceRequest] DataSourceRequest request)
        {
            try
            {
                // Retrieve and return data here
                var data = GetDestinationData(); // Implement this method to retrieve your data

                return Json(data.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                // Log the exception for debugging purposes
                Console.WriteLine(ex.Message);

                // Handle the exception gracefully, e.g., return an error message
                return Json(new DataSourceResult
                {
                    Errors = "An error occurred while retrieving data."
                });
            }
        }

        // Sample data retrieval method
        private IEnumerable<DestinationViewModel> GetDestinationData()
        {
            // Replace this with your actual data retrieval logic
            var data = db.DestinationViewModel.ToList();

            return data;
        }

        // Dispose of the database context when done
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