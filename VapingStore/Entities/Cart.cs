using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VapingStore.Entities
{
    public class Cart
    {
        private List<CartLine> lineCollection = new List<CartLine>();

        public IEnumerable<CartLine> Lines { get { return lineCollection; } }

        public void AddItem(ElectronicCigarettes cigarettes, int quantity)
        {
            CartLine line = lineCollection
                .Where(c => c.ElectronicCigarettes.ElectronicCigarettesId == cigarettes.ElectronicCigarettesId)
                .FirstOrDefault();
            if(line == null)
            {
                lineCollection.Add(new CartLine { ElectronicCigarettes = cigarettes, Quantity = quantity });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public void RemoveLine(ElectronicCigarettes cigarettes)
        {
            lineCollection.RemoveAll(l => l.ElectronicCigarettes.ElectronicCigarettesId == cigarettes.ElectronicCigarettesId);
        }

        public decimal ComputeTotalValue
        {
            get
            {
                return lineCollection.Sum(e => e.ElectronicCigarettes.Price * e.Quantity);
            }
        }

        public void Clear()
        {
            lineCollection.Clear();
        }
    }

    public class CartLine
    {
        public ElectronicCigarettes ElectronicCigarettes { get; set; }
        public int Quantity { get; set; }
    }
}
