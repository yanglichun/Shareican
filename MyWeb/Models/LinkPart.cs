using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWeb.Models
{
    public partial class Link
    {
        public DTO.LinkDTO ToDto()
        {
            return new DTO.LinkDTO()
            {
                  CreatDate=this.CreatDate,
                   id=this.id,
                    Isdel=this.Isdel,
                     LinkName=this.LinkName,
                      LinkUrl=this.LinkUrl,
                       Remark=this.Remark,
                        Sort=this.Sort

            };

        }
    }
}