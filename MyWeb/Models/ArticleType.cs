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
    
    public partial class ArticleType
    {
        public ArticleType()
        {
            this.Articles = new HashSet<Article>();
        }
    
        public int id { get; set; }
        public string TypeName { get; set; }
        public Nullable<System.DateTime> CreatDate { get; set; }
        public Nullable<System.DateTime> ChangeDate { get; set; }
        public Nullable<bool> Isdel { get; set; }
    
        public virtual ICollection<Article> Articles { get; set; }
    }
}
