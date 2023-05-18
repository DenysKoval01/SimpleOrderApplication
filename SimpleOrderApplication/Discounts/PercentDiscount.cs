using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleOrderApplication.Discounts
{
    public class PercentDiscount : IDiscount
    {
        public decimal PercentDiscountValue;
        public PercentDiscount(decimal percentDiscountValue)
        {
            if (percentDiscountValue < 0 || percentDiscountValue > 100) throw new ArgumentOutOfRangeException("Percent Discount Value be between 0 and 100.");
            PercentDiscountValue = percentDiscountValue;
        }


        public decimal GetDiscount(decimal price)
        {
            return price * (PercentDiscountValue / 100);
        }
    }
}
