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
    
    public partial class Status
    {
        public int StatusId { get; set; }
        public Nullable<int> MasterID { get; set; }
        public string ContactType { get; set; }
        public Nullable<System.DateTime> ContactDate { get; set; }
        public string WorkedBy { get; set; }
        public Nullable<System.DateTime> WorkedDate { get; set; }
    
        public virtual ClientMaster ClientMaster { get; set; }
    }
}
