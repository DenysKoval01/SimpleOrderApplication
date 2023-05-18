using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleOrderApplication.Discounts
{
    public interface IDiscount
    {
        decimal GetDiscount(decimal price);
    }
}
