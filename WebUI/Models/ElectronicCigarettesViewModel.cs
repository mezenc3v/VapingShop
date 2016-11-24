using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain.Entities;
namespace WebUI.Models
{
    public class ElectronicCigarettesViewModel
    {
        public IEnumerable<ElectronicCigarettes> ElectronicCigarettes { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}