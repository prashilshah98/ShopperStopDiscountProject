using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopperStopSolution.Domain
{
    public class GoldDiscountStrategy : ProgressiveDiscountStrategy
    {
        protected override List<DiscountSlab> Slabs => new()
        {
            new DiscountSlab { From = 0,      To = 5000,            Rate = 0.05m },
            new DiscountSlab { From = 5000,   To = 10000,           Rate = 0.10m },
            new DiscountSlab { From = 10000,  To = decimal.MaxValue, Rate = 0.15m }
        };
    }
}
