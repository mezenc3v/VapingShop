using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VapingStore.Entities;

namespace VapingStore.Models
{
    public class ElectronicCigarettesViewModel
    {
        public IEnumerable<ElectronicCigarettes> ElectronicCigarettes { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentCategory { get; set; }
    }
}