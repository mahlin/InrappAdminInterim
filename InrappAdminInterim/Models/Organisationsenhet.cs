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
    
    public partial class Organisationsenhet
    {
        public int organisationsenhetsid { get; set; }
        public int organisationsid { get; set; }
        public string enhetsnamn { get; set; }
        public string enhetskod { get; set; }
        public System.DateTime aktivfrom { get; set; }
        public Nullable<System.DateTime> aktivtom { get; set; }
        public System.DateTime skapaddatum { get; set; }
        public string skapadav { get; set; }
        public System.DateTime andraddatum { get; set; }
        public string andradav { get; set; }
    
        public virtual Organisation Organisation { get; set; }
    }
}