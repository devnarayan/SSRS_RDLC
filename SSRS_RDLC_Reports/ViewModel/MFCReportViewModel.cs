using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSRS_RDLC_Reports.Models
{
    public class MFCReportViewModel
    {
        public int MasterID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string DateOfBirth { get; set; }

        public string Gender { get; set; }

        public string MI { get; set; }

        public string SSN { get; set; }

        public string MedicaidID { get; set; }

        public string KidCareID { get; set; }

        public string Phone1 { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Zip { get; set; }

        public string MMI { get; set; }

        public int? R_Status { get; set; }

        public string A_Status { get; set; }

        public int? AreaOfficeCode { get; set; }
        public string AreaOfficeName { get; set; }
        public string Race { get; set; }
        public DateTime? WorkedDate { get; set; }
        public DateTime? AdmitDate { get; set; }
        public DateTime? DischargeDate { get; set; }
        public DateTime? ReferralDate { get; set; }
        public string WorkedBy { get; set; }
        public string LOC { get; set; }
        public string LOR { get; set; }
        public bool ISEnrolled { get; set; }
    }
}