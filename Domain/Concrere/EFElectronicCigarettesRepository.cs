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

        public void SaveCigarettes(ElectronicCigarettes cigarettes)
        {
            if(cigarettes.ElectronicCigarettesId == 0)
            {
                context.ElectronicCigarettes.Add(cigarettes);
            }
            else
            {
                ElectronicCigarettes dbEntry = context.ElectronicCigarettes.Find(cigarettes.ElectronicCigarettesId);
                if(dbEntry != null)
                {
                    dbEntry.ElectronicCigarettesId = cigarettes.ElectronicCigarettesId;
                    dbEntry.Name = cigarettes.Name;
                    dbEntry.Produser = cigarettes.Produser;
                    dbEntry.Weight = cigarettes.Weight;
                    dbEntry.Length = cigarettes.Length;
                    dbEntry.Price = cigarettes.Price;
                    dbEntry.BattaryPower = cigarettes.BattaryPower;
                    dbEntry.CurrentCategory = cigarettes.CurrentCategory;
                }
            }
            context.SaveChanges();
        }
        public void DelCigarettes(ElectronicCigarettes cigarettes)
        {
                ElectronicCigarettes dbEntry = context.ElectronicCigarettes.Find(cigarettes.ElectronicCigarettesId);
                if (dbEntry != null)
                {
                    context.ElectronicCigarettes.Remove(dbEntry);
                }
            context.SaveChanges();
        }
        public void AddCigarettes(ElectronicCigarettes cigarettes)
        {
            context.ElectronicCigarettes.Add(cigarettes);
            context.SaveChanges();
        }
    }
}
