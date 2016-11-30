using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VapingStore.Entities;

namespace VapingStore.Concrere
{
    public class EFDbContext : DbContext
    {
        public DbSet<ElectronicCigarettes> ElectronicCigarettes { get; set; }
    }
}

