using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Telerik_Project15.Models
{
    public class DashboardViewModel
    {
        public List<int> BarChartData { get; set; }
        public List<int> LineChartData { get; set; }
        public List<TableData> TableDataList { get; set; }
        public object CustomerData { get; internal set; }
    }

    public class TableData
    {
        public string Name { get; set; }
        public int Value { get; set; }
    }
}