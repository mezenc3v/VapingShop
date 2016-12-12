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
    public class EFShopingDetailsRepository : IShopingDetailsRepository
    {
        EFDbContext context = new EFDbContext();

        public IEnumerable<ShopingDetails> ShopingDetails
        {
                get { return context.ShopingDetails; }
        }

        public void AddShopingDetails(ShopingDetails details)
        {

            context.ShopingDetails.Add(details);
            context.SaveChanges();
        }

    }
}
