//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OnlineLicensing.Api.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class LICENSEPRODUCT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LICENSEPRODUCT()
        {
            this.LICENSEDETAILs = new HashSet<LICENSEDETAIL>();
            this.ORDERS = new HashSet<ORDER>();
        }
    
        public int product_id { get; set; }
        public string sku { get; set; }
        public string name { get; set; }
        public bool active { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LICENSEDETAIL> LICENSEDETAILs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ORDER> ORDERS { get; set; }
    }
}
