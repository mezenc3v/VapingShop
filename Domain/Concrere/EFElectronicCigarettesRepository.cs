using Domain.Abstract;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Concrere
{
    public class EFElectronicCigarettesRepository : IElectronicCigarettesRepository
    {
        EFDbContext context = new EFDbContext();

        public IEnumerable<ElectronicCigarettes> ElectronicCigarettes
        {
                get { return context.ElectronicCigarettes; }
        }
    }
}
