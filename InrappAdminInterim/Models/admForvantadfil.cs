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
    
    public partial class admForvantadfil
    {
        public int forvantadfilid { get; set; }
        public int filkravid { get; set; }
        public Nullable<int> foreskriftsid { get; set; }
        public string filmask { get; set; }
        public string regexp { get; set; }
        public bool obligatorisk { get; set; }
        public bool tom { get; set; }
        public System.DateTime skapaddatum { get; set; }
        public string skapadav { get; set; }
        public System.DateTime andraddatum { get; set; }
        public string andradav { get; set; }
    }
}