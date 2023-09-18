using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Telerik_Project15.Models;

namespace Telerik_Project15.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
        public ActionResult Index()
        {
            var model = new DashboardViewModel
            {
                BarChartData = new List<int> { 10, 20, 30, 40, 50 },
                LineChartData = new List<int> { 50, 40, 30, 20, 10 },
                TableDataList = new List<TableData>
        {
            new TableData { Name = "Item 1", Value = 100 },
            new TableData { Name = "Item 2", Value = 200 },
            new TableData { Name = "Item 3", Value = 300 },
            new TableData { Name = "Item 4", Value = 400 },
            new TableData { Name = "Item 5", Value = 500 }
        }
            };

            return View(model);
        }
    }
}