﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class CAP30Entities : DbContext
    {
        public CAP30Entities()
            : base("name=CAP30Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AreaOffice> AreaOffices { get; set; }
        public virtual DbSet<ClientAreaOffice> ClientAreaOffices { get; set; }
        public virtual DbSet<ClientMaster> ClientMasters { get; set; }
        public virtual DbSet<CMAT_Assessment> CMAT_Assessment { get; set; }
        public virtual DbSet<CMAT_PC> CMAT_PC { get; set; }
        public virtual DbSet<MFC_Status_LK> MFC_Status_LK { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<CM_AttachmentType_LK> CM_AttachmentType_LK { get; set; }
        public virtual DbSet<CMAT_PC_DischargeDisposition_LK> CMAT_PC_DischargeDisposition_LK { get; set; }
        public virtual DbSet<CMAT_PC_MFC_ClientOrigination_LK> CMAT_PC_MFC_ClientOrigination_LK { get; set; }
        public virtual DbSet<CMAT_PC_MFC_DischargeDest_LK> CMAT_PC_MFC_DischargeDest_LK { get; set; }
        public virtual DbSet<CMAT_PC_MFC_Reason_LK> CMAT_PC_MFC_Reason_LK { get; set; }
        public virtual DbSet<CMAT_PC_MPC_LevelOfCare_LK> CMAT_PC_MPC_LevelOfCare_LK { get; set; }
        public virtual DbSet<CMAT_Staffing_Discharge_LK> CMAT_Staffing_Discharge_LK { get; set; }
    }
}
