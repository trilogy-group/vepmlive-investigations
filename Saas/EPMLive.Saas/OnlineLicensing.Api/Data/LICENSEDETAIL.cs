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
    
    public partial class LicenseDetail
    {
        public int license_detail_id { get; set; }
        public int product_id { get; set; }
        public Nullable<int> detail_type_id { get; set; }
        public Nullable<int> contract_id { get; set; }
    
        public virtual LicenseProduct LicenseProduct { get; set; }
        public virtual DetailType DetailType { get; set; }
    }
}
