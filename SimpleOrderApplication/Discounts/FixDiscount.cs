using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleOrderApplication.Discounts
{
    public class FixDiscount : IDiscount
    {

        public decimal DiscountAmount;

        public FixDiscount(decimal discountAmount)
        {
            if (discountAmount < 0) throw new ArgumentOutOfRangeException("Discount amount be negative.");
            DiscountAmount = discountAmount;
        }
        public decimal GetDiscount(decimal price)
        {
            if (price > DiscountAmount) return DiscountAmount;
            else return price;
        }
    }
}
