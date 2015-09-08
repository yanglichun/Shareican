using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWeb.Models.DTO
{
    public class LinkDTO
    {

        public int id { get; set; }
        public string LinkName { get; set; }
        public string LinkUrl { get; set; }
        public string Remark { get; set; }
        public Nullable<System.DateTime> CreatDate { get; set; }
        public Nullable<int> Sort { get; set; }
        public Nullable<bool> Isdel { get; set; }
    }
}