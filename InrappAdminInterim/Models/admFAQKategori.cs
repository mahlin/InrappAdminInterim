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
    
    public partial class admFAQKategori
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public admFAQKategori()
        {
            this.admFAQs = new HashSet<admFAQ>();
        }
    
        public int faqkatergoriid { get; set; }
        public string kategori { get; set; }
        public System.DateTime skapaddatum { get; set; }
        public string skapadav { get; set; }
        public System.DateTime andraddatum { get; set; }
        public string andradav { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<admFAQ> admFAQs { get; set; }
    }
}