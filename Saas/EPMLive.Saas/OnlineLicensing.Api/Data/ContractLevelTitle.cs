//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EPMLive.OnlineLicensing.Api.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class ContractLevelTitle
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ContractLevelTitle()
        {
            this.ContractLevels = new HashSet<ContractLevel>();
        }
    
        public int ContractLevel { get; set; }
        public string TITLE { get; set; }
        public Nullable<int> GroupId { get; set; }
        public string Template { get; set; }
        public Nullable<int> TrialUsers { get; set; }
        public Nullable<int> TrialMonths { get; set; }
        public Nullable<int> DETAIL_ID { get; set; }
        public Nullable<bool> salesonly { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ContractLevel> ContractLevels { get; set; }
    }
}
