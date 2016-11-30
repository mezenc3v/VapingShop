﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Abstract
{
    public interface IElectronicCigarettesRepository
    {
        IEnumerable<ElectronicCigarettes> ElectronicCigarettes { get; }
        void SaveCigarettes(ElectronicCigarettes cigarettes);
        void AddCigarettes(ElectronicCigarettes cigarettes);
        void DelCigarettes(ElectronicCigarettes cigarettes);
    }
}
