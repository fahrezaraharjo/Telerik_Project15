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
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetBarChartData()
        {
            var data = new List<ChartDataModel>
        {
            new ChartDataModel { Category = "Category 1", Value = 10 },
            new ChartDataModel { Category = "Category 2", Value = 20 },
            new ChartDataModel { Category = "Category 3", Value = 15 }
        };

            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetLineChartData()
        {
            var data = new List<ChartDataModel>
        {
            new ChartDataModel { Category = "Category 1", Value = 5 },
            new ChartDataModel { Category = "Category 2", Value = 15 },
            new ChartDataModel { Category = "Category 3", Value = 10 }
        };

            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}