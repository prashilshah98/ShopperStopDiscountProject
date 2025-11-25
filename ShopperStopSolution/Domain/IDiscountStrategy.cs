using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopperStopSolution.Domain
{
    public interface IDiscountStrategy
    {
        decimal GetDiscount(decimal amount);
    }
}
