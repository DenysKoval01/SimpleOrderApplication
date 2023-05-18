using SimpleOrderApplication.Discounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleOrderApplication.Orders
{
    public class OrderItem
    {
        public string Name { get; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal Discount { get; set; }
        public decimal Amount { get;  set; }
        public decimal NewPrice { get;  set; }



        public OrderItem(string name, decimal price, int quantity,decimal discount,decimal newPrice)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
            //strange to create IDiscount and after that apply Discount to 0;
            //lets use fourth parameter like parameter
            Discount = discount;

            NewPrice = newPrice;
            RecalculateAmount();
        }

        private void RecalculateAmount()
        {
            Amount = Quantity * Price - Discount;
        }

        public override string ToString()
        {
            return $"{GetType().Name}: Name={Name}, Price={Price}, Quantity={Quantity}, Discount={Discount}, Amount={Amount}";
        }



    }
}
