//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace E_Market_Project_ASP_NET_MVC.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_admin
    {
        public tbl_admin()
        {
            this.tbl_category = new HashSet<tbl_category>();
        }
    
        public int ad_id { get; set; }
        public string ad_username { get; set; }
        public string ad_password { get; set; }
    
        public virtual ICollection<tbl_category> tbl_category { get; set; }
    }
}
