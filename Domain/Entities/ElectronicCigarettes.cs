using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ElectronicCigarettes
    {
        public int ElectronicCigarettesId { get; set; }
        public string Name { get; set; }
        public string Produser { get; set; }
        public int Weight { get; set; }
        public int Length { get; set; }
        public int BattaryPower { get; set; }
        public decimal Price { get; set; }
    }
}
