using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSRS_RDLC_Reports.ViewModel
{
    public class HeaderFilterModel
    {
        public int TotalCount { get; set; }
        public int DistinctCount { get; set; }

        public string ReportType { get; set; } 
        public string Status { get; set; }
        public string LocType { get; set; }
        public string OptionSelection { get; set; }
        public string AreaOfficeCode { get; set; }
        public string DateType { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
    }
}