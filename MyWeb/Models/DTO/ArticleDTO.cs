using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWeb.Models.DTO
{
    public class ArticleDTO
    {
        public int id { get; set; }
        public string Title { get; set; }
        public string ArticleContent { get; set; }
        public string CoverImage { get; set; }
        public Nullable<int> PublisherID { get; set; }
        public Nullable<System.DateTime> CreatDate { get; set; }
        public Nullable<System.DateTime> ChangeDate { get; set; }
        public string Source { get; set; }
        public Nullable<int> ClickTimes { get; set; }
        public Nullable<int> TypeID { get; set; }
        public string Label { get; set; }
        public Nullable<int> AgreeTimes { get; set; }
        public Nullable<bool> Isdel { get; set; }
        public string Equipment { get; set; }
        public Nullable<int> Sort { get; set; }
        public Nullable<int> AgainstTimes { get; set; }
        public string SourceUrl { get; set; }
    }
}