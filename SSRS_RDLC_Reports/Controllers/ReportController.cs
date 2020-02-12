using SSRS_RDLC_Reports.Models;
using SSRS_RDLC_Reports.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SSRS_RDLC_Reports.Controllers
{
    public class ReportController : Controller
    {
        //
        // GET: /Report/

        public ActionResult ReportTemplate(string ReportName, string ReportDescription, string searchQuery, int Width, int Height)
        {
            var rptInfo = new ReportInfo
            {
                ReportName = ReportName,
                ReportDescription = ReportDescription,
                ReportURL = String.Format("../../Reports/ReportTemplate.aspx?ReportName={0}&Height={1}&{2}", ReportName, Height, searchQuery),
                Width = Width,
                Height = Height
            };

            return View(rptInfo);
        }

        public ActionResult Report(string reportType, string status, string optionSelection, string areaOfficeCode,
           string locType, string dateType, DateTime? dateFrom, DateTime? dateTo)
        {
            SSRS_RDLC_Reports.Models.CAP30Entities entities = new CAP30Entities();
            ViewBag.clientorg = entities.CMAT_PC_MFC_ClientOrigination_LK.ToList().Select(co => new SelectListItem { Text = co.ClientOrigination, Value = co.ClientOriginationID.ToString() }).ToList();
            ViewBag.DischargeDest = entities.CMAT_PC_MFC_DischargeDest_LK.ToList().Select(dd => new SelectListItem { Text = dd.DischargeDestDesc, Value = dd.DischargeDestID.ToString() }).ToList();
            ViewBag.Reason = entities.CMAT_PC_MFC_Reason_LK.ToList().Select(r => new SelectListItem { Text = r.ReasonDesc, Value = r.MFCPC_ReasonID.ToString() }).ToList();
            ViewBag.loc = entities.CMAT_PC_MPC_LevelOfCare_LK.ToList().Select(loc => new SelectListItem { Text = loc.MPC_LevelOfCare, Value = loc.MPC_L_CareID.ToString() }).ToList();
            ViewBag.MFCStatus = entities.MFC_Status_LK.ToList().Select(MFCStatus => new SelectListItem { Text = MFCStatus.MFC_Status, Value = MFCStatus.MFC_StatusID.ToString() }).ToList();

            ViewBag.AreaOffices = entities.AreaOffices.ToList()
                .Select(st => new SelectListItem { Text = st.AreaOfficeName, Value = st.AreaOfficeCode.ToString() }).ToList();

            var ReportName = "MFC_DiagnosisLOR"; var Height = 650; 
            var searchQuery = "reportType=" + reportType + "&status=" + status + "&optionSelection=" + optionSelection + "&areaOfficeCode=" + areaOfficeCode
                      + "&locType=" + locType + "&dateType=" + dateType + "&dateFrom=" + dateFrom + "&dateTo=" + dateTo;
            var rptInfo = new ReportInfo
            {
                ReportName = ReportName,
                ReportDescription = "",
                ReportURL = String.Format("../../Reports/ReportTemplate.aspx?ReportName={0}&Height={1}&{2}", ReportName, Height, searchQuery),
                Width = 100,
                Height = Height
            };

            return View(rptInfo);
        }

        [HttpGet]
        public JsonResult GetMFCReport(string reportType, string status, string optionSelection, string areaOfficeCode, 
           string locType, string dateType, DateTime dateFrom, DateTime dateTo)
        {

            //var Results = GetMFCReportData(reportType, optionSelection, areaOfficeCode, subReportType, dateFrom, dateTo);
            return Json(null, JsonRequestBehavior.AllowGet);
        }

    }
}
