using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using VapingStore.Abstract;
using VapingStore.Entities;

namespace VapingStore.Concrere
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
                    dbEntry.Weight = cigarettes.Weight;
                    dbEntry.Size = cigarettes.Size;
                    dbEntry.Price = cigarettes.Price;
                    dbEntry.BattaryPower = cigarettes.BattaryPower;
                    dbEntry.Produser = cigarettes.Produser;
                    dbEntry.Blowout = cigarettes.Blowout;
                    dbEntry.Connector = cigarettes.Connector;
                    dbEntry.Description = cigarettes.Description;
                    dbEntry.Image = cigarettes.Image;
                    dbEntry.Resistance = cigarettes.Resistance;
                    dbEntry.Socket = cigarettes.Socket;
                    dbEntry.Time = cigarettes.Time;
                    dbEntry.Volume = cigarettes.Volume;
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
