//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SSRS_RDLC_Reports.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class CMAT_PC
    {
        public int CMAT_PCID { get; set; }
        public int MasterID { get; set; }
        public Nullable<int> CMATID { get; set; }
        public string StaffingDt { get; set; }
        public string FirstStaffingDt { get; set; }
        public string FirstStaffingDt2 { get; set; }
        public Nullable<System.DateTime> NextStaffingDt { get; set; }
        public Nullable<int> Duration { get; set; }
        public string StaffingType { get; set; }
        public Nullable<System.DateTime> C_DischargeDt { get; set; }
        public string CMAT_Status { get; set; }
        public string ProgramEligibility { get; set; }
        public string L_Reimbursement { get; set; }
        public string L_Care { get; set; }
        public string ModelWaiver { get; set; }
        public string PreviousStability { get; set; }
        public string CurrentStability { get; set; }
        public string DischargeDisposition { get; set; }
        public string OtherDischarge_D { get; set; }
        public string MMA_Plan { get; set; }
        public string MMA_CM_FN { get; set; }
        public string MMA_CM_LN { get; set; }
        public string MMA_Phone1 { get; set; }
        public string MMA_Phone2 { get; set; }
        public string MMA_Email { get; set; }
        public string MMA_Address { get; set; }
        public string AgencyName { get; set; }
        public string Dependency_CM_FN { get; set; }
        public string Dependency_CM_LN { get; set; }
        public string D_CM_Phone1 { get; set; }
        public string D_CM_Phone2 { get; set; }
        public string D_CM_Email { get; set; }
        public string D_CM_Address { get; set; }
        public string MFC_P_FN { get; set; }
        public string MFC_P_LN { get; set; }
        public string MFC_P_Phone1 { get; set; }
        public string MFC_P_Phone2 { get; set; }
        public string MFC_P_Email { get; set; }
        public string MFC_P_Address { get; set; }
        public string WorkedBy { get; set; }
        public Nullable<System.DateTime> WorkedDate { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public string StaffingTypeComments { get; set; }
        public string StaffingAttachment { get; set; }
        public Nullable<int> MFCID { get; set; }
        public Nullable<System.DateTime> MPC_MFCReferralDt { get; set; }
        public Nullable<bool> MPC_ClientPlaced { get; set; }
        public string MPC_Comments { get; set; }
        public Nullable<int> MPC_ClientOrigination { get; set; }
        public string MPC_ClientOrigination_Other { get; set; }
        public Nullable<System.DateTime> MPC_AdmitDt { get; set; }
        public Nullable<System.DateTime> MPC_DischargeDt { get; set; }
        public string MPC_L_Care { get; set; }
        public Nullable<int> MPC_DischargeDest { get; set; }
        public string MPC_DischargeDest_Other { get; set; }
        public Nullable<int> MPC_ReasonNotPlaced { get; set; }
        public string MPC_ReasonNotPlaced_Other { get; set; }
        public string First_L_Care { get; set; }
        public string First_L_Reimbursement { get; set; }
        public string MMA_Phone1Ext { get; set; }
        public string MMA_Phone2Ext { get; set; }
        public string D_CM_Phone1Ext { get; set; }
        public string D_CM_Phone2Ext { get; set; }
        public string MFC_P_Phone1Ext { get; set; }
        public string MFC_P_Phone2Ext { get; set; }
        public Nullable<int> MFC_StatusID { get; set; }
        public Nullable<System.DateTime> MFC_StatusID_Dt { get; set; }
        public Nullable<System.DateTime> LOC_StartDt { get; set; }
        public Nullable<System.DateTime> LOC_EndDt { get; set; }
        public Nullable<int> TotalApprovedDuuration { get; set; }
    
        public virtual ClientMaster ClientMaster { get; set; }
    }
}
