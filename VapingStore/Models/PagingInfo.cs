using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VapingStore.Models
{
    public class PagingInfo
    {
        public int TotalItems { get; set; }     //всего сигарет
        public int ItemsPerPage { get; set; }   //количество сигарет на странице
        public int CurrentPage { get; set; }    //номер текущей страницы

        public int TotalPages                   //общее число страниц
        {   
            get { return (int) Math.Ceiling((decimal) TotalItems/ItemsPerPage); }
        }
    }
}