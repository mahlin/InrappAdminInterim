//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace InrappAdminInterim.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class admFAQ
    {
        public int faqid { get; set; }
        public Nullable<int> registerid { get; set; }
        public Nullable<int> faqkatergoriid { get; set; }
        public string fraga { get; set; }
        public string svar { get; set; }
        public System.DateTime skapaddatum { get; set; }
        public string skapadav { get; set; }
        public System.DateTime andraddatum { get; set; }
        public string andradav { get; set; }
    
        public virtual admFAQKategori admFAQKategori { get; set; }
        public virtual admRegister admRegister { get; set; }
    }
}
