using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VapingStore.Entities;

namespace VapingStore.Abstract
{
    public interface IElectronicCigarettesRepository
    {
        IEnumerable<ElectronicCigarettes> ElectronicCigarettes { get; }
        void SaveCigarettes(ElectronicCigarettes cigarettes);
        void AddCigarettes(ElectronicCigarettes cigarettes);
        void DelCigarettes(ElectronicCigarettes cigarettes);
    }
}
