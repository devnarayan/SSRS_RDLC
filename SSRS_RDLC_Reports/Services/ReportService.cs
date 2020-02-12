using SSRS_RDLC_Reports.Common;
using SSRS_RDLC_Reports.Models;
using SSRS_RDLC_Reports.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;

namespace CAP.Services
{
    public class ReportService
    {
        public Tuple<string, List<string>, List<object>, NameValueCollection> GetReportData(string reportName, NameValueCollection coll)
        {
            List<string> dataSets = new List<string>(); string reportUrl = ""; List<object> dataSources = new List<object>(); NameValueCollection parameters = new NameValueCollection();
            if (reportName == ReportName.MFC_DiagnosisLOR.ToString())
            {
                parameters.Add("DateRange", "DD");
                parameters.Add("DateRangeName", "DDName");
                reportUrl = "MFC/MFCDiagnosis.rdlc";

                var filter = GetHeaderFilter(coll);
                var data = GetMFCReportData(filter.ReportType, filter.Status, filter.OptionSelection, filter.AreaOfficeCode, filter.LocType, filter.DateType, filter.DateFrom ?? DateTime.Now, filter.DateTo ?? DateTime.Now);

                dataSets.Add("MFCDiagnosisDataSet");
                dataSources.Add(data.Item1);

                dataSets.Add("HeaderFilterDataSet");
                dataSources.Add(data.Item2);
            }
            return new Tuple<string, List<string>, List<object>, NameValueCollection>(reportUrl, dataSets, dataSources, parameters);
        }

        private HeaderFilterModel GetHeaderFilter(NameValueCollection coll)
        {
            HeaderFilterModel filter = new HeaderFilterModel();
            for (int i = 0; i < coll.Count; i++)
            {
                var nameValue = coll[i];
                var name = coll.AllKeys[i];
                if (name == "reportType")
                {
                    filter.ReportType = nameValue;
                }
                else if (name == "optionSelection")
                {
                    filter.OptionSelection = nameValue;
                }
                else if (name == "status")
                {
                    filter.Status = nameValue;
                }
                else if (name == "areaOfficeCode")
                {
                    filter.AreaOfficeCode = nameValue;
                }
                else if (name == "locType")
                {
                    filter.LocType = nameValue;
                }
                else if (name == "dateType")
                {
                    filter.DateType = nameValue;
                }
                else if (name == "dateFrom")
                {
                    filter.DateFrom = Convert.ToDateTime(nameValue);
                }
                else if (name == "dateTo")
                {
                    filter.DateTo = Convert.ToDateTime(nameValue);
                }
            }


            return filter;
        }
        private Tuple<List<MFCReportViewModel>, List<HeaderFilterModel>> GetMFCReportData(string reportType, string status, string optionSelection, string areaOfficeCode, string locType, string dateType,
            DateTime dateFrom, DateTime dateTo)
        {
            List<HeaderFilterModel> filterList = new List<HeaderFilterModel>();
            HeaderFilterModel filter = new HeaderFilterModel();
            filter.DateFrom = dateFrom;
            filter.DateTo = dateTo;
            filter.AreaOfficeCode = areaOfficeCode;
            filter.ReportType = reportType;

            SSRS_RDLC_Reports.Models.CAP30Entities entities = new CAP30Entities();
            var areaOfficeInt = 0;
            if (areaOfficeCode != "0")
            {
                areaOfficeInt = Convert.ToInt32(areaOfficeCode);
                filter.AreaOfficeCode = entities.AreaOffices.Where(st => st.AreaOfficeCode == areaOfficeInt).Select(st => st.AreaOfficeName).FirstOrDefault();
            }
            else
            {
                filter.AreaOfficeCode = "All";
            }

            MFCReportViewModel vm = new MFCReportViewModel();
            List<MFCReportViewModel> data = new List<MFCReportViewModel>();
            var query = (from st in entities.ClientMasters
                         join pc in entities.CMAT_PC on st.MasterID equals pc.MasterID
                         join area in entities.ClientAreaOffices on st.MasterID equals area.MasterID
                         where areaOfficeInt == 0 || area.AreaOfficeCode == areaOfficeInt
                         select new { st, pc, area }).AsQueryable();

            if (status != "0")
            {
                int statusInt = Convert.ToInt32(status);
                filter.Status = entities.MFC_Status_LK.Where(st => st.MFC_StatusID == statusInt).Select(f => f.MFC_Status).FirstOrDefault();
                query = query.Where(st => st.pc.MFC_StatusID == statusInt);
            }
            else
            {
                filter.Status = "All";
            }

            if (dateType == "AdmitDateOption")
            {
                filter.DateType = "Admit Date";
                query = query.Where(st => st.pc.MPC_AdmitDt >= dateFrom && st.pc.MPC_AdmitDt <= dateTo);
            }
            else if (dateType == "DischargeDateOption")
            {
                filter.DateType = "Discharge Date";
                query = query.Where(st => st.pc.MPC_DischargeDt >= dateFrom && st.pc.MPC_DischargeDt <= dateTo);
            }
            else if (dateType == "ReferralDateOption")
            {
                filter.DateType = "Referral Date";
                query = query.Where(st => st.pc.MPC_MFCReferralDt >= dateFrom && st.pc.MPC_MFCReferralDt <= dateTo);
            }
            else if (dateType == "ReportDateOption")
            {
                filter.DateType = "Report Date";
                query = query.Where(st => st.pc.MPC_AdmitDt >= dateFrom && st.pc.MPC_DischargeDt <= dateTo);
            }

            if (reportType == "LOC")
            {
                if (locType == "ReferringLOC")
                {
                    filter.LocType = "Referring LOC";
                    filter.ReportType = "Referring LOC";
                    query = query.Where(st => (optionSelection == "All" || st.pc.MPC_L_Care == optionSelection)
                        && st.pc.MPC_AdmitDt >= dateFrom && st.pc.MPC_AdmitDt <= dateTo);
                }
                else if (locType == "DischargeLOC")
                {
                    filter.LocType = "Discharge LOC";
                    filter.ReportType = "Discharge LOC";
                    query = query.Where(st => (optionSelection == "All" || st.pc.L_Reimbursement == optionSelection)
                        && st.pc.MPC_AdmitDt >= dateFrom && st.pc.MPC_AdmitDt <= dateTo);
                }
                else if (locType == "MFCLOC")
                {
                    filter.LocType = "MFC LOC";
                    filter.ReportType = "MFC LOC";
                    query = query.Where(st => (optionSelection == "All" || st.pc.L_Care == optionSelection)
                        && st.pc.MPC_AdmitDt >= dateFrom && st.pc.MPC_AdmitDt <= dateTo);
                }
                else if (locType == "AdmitLOC")
                {
                    filter.LocType = "Admit LOC";
                    filter.ReportType = "Admit LOC";
                    query = query.Where(st => (optionSelection == "All" || st.pc.First_L_Reimbursement == optionSelection)
                        && st.pc.MPC_AdmitDt >= dateFrom && st.pc.MPC_AdmitDt <= dateTo);
                }
                else
                {
                    filter.ReportType = reportType;
                }
                filter.OptionSelection = optionSelection;
            }
          
            else if (reportType == "Diagnosis")
            {
                filter.OptionSelection = optionSelection;
            }
            else if (reportType == "NotPlacedReason")
            {
                if (optionSelection != "0")
                {
                    int selectedId = Convert.ToInt32(optionSelection);
                    filter.OptionSelection = entities.CMAT_PC_MFC_Reason_LK.Where(st => st.MFCPC_ReasonID == selectedId).Select(st => st.ReasonDesc).FirstOrDefault();
                    query = query.Where(st => st.pc.MPC_ReasonNotPlaced == selectedId);
                }
                else
                {
                    filter.OptionSelection = "All";
                }
                filter.ReportType = "Not Placed Reason";

            }
            else if (reportType == "DischargeDestination")
            {
                if (optionSelection != "0")
                {
                    int selectedId = Convert.ToInt32(optionSelection);
                    filter.OptionSelection = entities.CMAT_PC_MFC_DischargeDest_LK.Where(st => st.DischargeDestID == selectedId).Select(st => st.DischargeDestDesc).FirstOrDefault();
                    query = query.Where(st => st.pc.MPC_DischargeDest == selectedId);
                }
                else
                {
                    filter.OptionSelection = "All";
                }
                filter.ReportType = "Discharge Destination";

            }
            else if (reportType == "Provider")
            {
                if (optionSelection != "0")
                {
                    int selectedId = Convert.ToInt32(optionSelection);
                    filter.OptionSelection = entities.CMAT_PC_MFC_ClientOrigination_LK.Where(st => st.ClientOriginationID == selectedId).Select(st => st.ClientOrigination).FirstOrDefault();
                    query = query.Where(st => st.pc.MPC_ClientOrigination == selectedId);
                }
                else
                {
                    filter.OptionSelection = "All";
                }
                filter.ReportType = "Client Origination";

            }

            data = (from q in query
                    select new MFCReportViewModel()
                    {
                        MasterID = q.st.MasterID,
                        LastName = q.st.LastName ?? "",
                        FirstName = q.st.FirstName ?? "",
                        SSN = string.IsNullOrEmpty(q.st.SSN) ? "" : q.st.SSN,
                        MedicaidID = q.st.MedicaidID,
                        DateOfBirth = q.st.DateOfBirth,
                        Race = q.st.Race,
                        Gender = q.st.Gender,
                        R_Status = q.st.R_Status == null ? 0 : q.st.R_Status.Value,
                        KidCareID = q.st.KidCareID,
                        AreaOfficeCode = q.area.AreaOfficeCode,
                        WorkedDate = q.st.WorkedDate,
                        AdmitDate = q.pc.MPC_AdmitDt,
                        DischargeDate = q.pc.MPC_DischargeDt,
                        ReferralDate = q.pc.MPC_MFCReferralDt,
                        WorkedBy = q.st.WorkedBy,
                        LOC = locType == "AdmitLOC" ? q.pc.L_Care
                        : locType == "ReferringLOC" ? q.pc.First_L_Reimbursement
                        : locType == "DischargeLOC" ? q.pc.First_L_Reimbursement
                        : locType == "MFCLOC" ? q.pc.First_L_Reimbursement : q.pc.MPC_L_Care,
                        LOR = q.pc.L_Reimbursement,
                        ISEnrolled = q.st.isEnrolled == true ? true : false
                    }).OrderByDescending(od => od.WorkedDate).ToList();
            if (data.Count > 0)
            {
                var areaOffice = entities.AreaOffices
                    //.Where(st=> userAreaOffce.Contains(st.AreaOfficeCode)
                    .ToList();
                foreach (var record in data)
                {
                    record.AreaOfficeName = areaOffice.Where(st => st.AreaOfficeCode == record.AreaOfficeCode).Select(st => st.AreaOfficeName).FirstOrDefault();
                    record.DateOfBirth = CommonFormat.DOBFormat(record.DateOfBirth);
                    record.SSN = CommonFormat.RemoveSpecialCharacters(record.SSN);
                }

            }

            filter.TotalCount = data.Count;
            filter.DistinctCount = data.Select(st => st.MasterID).Distinct().Count();
            filterList.Add(filter);
            return new Tuple<List<MFCReportViewModel>, List<HeaderFilterModel>>(data, filterList);
        }

    }
}