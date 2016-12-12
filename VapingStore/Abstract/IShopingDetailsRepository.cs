using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VapingStore.Entities;

namespace VapingStore.Abstract
{
    public interface IShopingDetailsRepository
    {
        IEnumerable<ShopingDetails> ShopingDetails { get; }
        void AddShopingDetails(ShopingDetails details);
    }
}
