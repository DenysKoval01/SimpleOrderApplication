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
        private decimal _price;
        private decimal _quantity;
        private decimal _discount;
        public string? Name { get; set; }
        public decimal Price
        {
            get { return _price; }
            set
            {
                _price = value;
                RecalculateAmount();
            }
        }
        public decimal Quantity
        {
            get { return _quantity; }
            set
            {
                _quantity = value;
                RecalculateAmount();
            }
        }
        public decimal Discount
        {
            get { return _discount; }
            set
            {
                _discount = value;
                RecalculateAmount();
            }
        }
        public decimal Amount { get; set; }
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
            Amount = price * quantity;
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
