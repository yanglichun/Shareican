using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWeb.Models
{
    public partial class Article
    {
        public DTO.ArticleDTO ToDto() 
       {
           return new DTO.ArticleDTO()
           {
               id=this.id,
                AgainstTimes=this.AgainstTimes,
                 AgreeTimes=this.AgreeTimes,
                  ArticleContent=this.ArticleContent,
                   ChangeDate=this.ChangeDate,
                    ClickTimes=this.ClickTimes,
                     CoverImage=this.CoverImage,
                      CreatDate=this.ChangeDate,
                       Equipment=this.Equipment,
                        Isdel=this.Isdel,
                         Label=this.Label,
                          PublisherID=this.PublisherID,
                           Sort=this.Sort,
                            Source=this.Source,
                             Title=this.Title,
                              TypeID=this.TypeID,
                               SourceUrl=this.SourceUrl


           };

        }
    }
}