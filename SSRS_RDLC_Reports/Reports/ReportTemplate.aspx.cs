using CAP.Services;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SSRS_RDLC_Reports.Reports
{
    public partial class ReportTemplate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    //RDLC
                    var reportName = Request["ReportName"].ToString();
                    var coll = Request.QueryString;
                    ReportService report = new ReportService();
                    var reportData = report.GetReportData(reportName, coll);
                    if (reportData.Item1 != "")
                    {
                        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Reports/" + reportData.Item1);
                        ReportViewer1.LocalReport.DataSources.Clear();

                        //Add the parameters to reportviewer.
                        if (reportData.Item4.Count > 0)
                        {
                            ReportParameter[] parameters = new ReportParameter[reportData.Item4.Count];
                            for(int i = 0; i < reportData.Item4.Count; i++)
                            {
                                var d = reportData.Item4[i];
                                parameters[i] = new ReportParameter(reportData.Item4.AllKeys[i], d);
                            }
                            ReportViewer1.LocalReport.SetParameters(parameters);
                        }

                        //Add the datasources to reportviewer.
                        if (reportData.Item2.Count > 0)
                        {
                            for(int i = 0; i < reportData.Item2.Count; i++)
                            {
                                ReportDataSource rdc = new ReportDataSource(reportData.Item2[i], reportData.Item3[i]);
                                ReportViewer1.LocalReport.DataSources.Add(rdc);
                            }
                        }
                      

                        ReportViewer1.LocalReport.Refresh();
                        ReportViewer1.DataBind();
                    }
                }
                catch (Exception ex)
                {

                }
            }
        }
    }
}