//------------------------------------------------------------------------------
// <auto-generated>
//    此代码是根据模板生成的。
//
//    手动更改此文件可能会导致应用程序中发生异常行为。
//    如果重新生成代码，则将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace MyWeb.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Announcement
    {
        public int id { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public string Publisher { get; set; }
        public Nullable<int> PublisherID { get; set; }
        public string Announcement1 { get; set; }
        public Nullable<bool> Isdel { get; set; }
        public Nullable<int> Sort { get; set; }
    }
}
