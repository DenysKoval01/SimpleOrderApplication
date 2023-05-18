using SimpleOrderApplication.Discounts;
using SimpleOrderApplication.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleOrderApplication.Orders
{
    public class Order
    {
        public List<OrderItem> orderItems;

        private readonly IDiscount? Discount;
        private decimal NewPrice;

        public Order()
        {
            orderItems = new List<OrderItem>();
        }

        public Order(IDiscount? discount = null) {
#pragma warning disable CS8601 // Possible null reference assignment.
            Discount = discount;
#pragma warning restore CS8601 // Possible null reference assignment.
            orderItems = new List<OrderItem>();
        }

        public void AddItem(Product product,int quantity) 
        {
            if (product is null) 
            {
                throw new ArgumentNullException("Product cannot be null.");

            }

            if (quantity < 0)
            {
                throw new ArgumentOutOfRangeException("Quantity cannot be negative.");
            }

            decimal discountAmount = 0;
            if (Discount != null)
            {
                discountAmount = Discount.GetDiscount(product.Price);
                NewPrice = product.Price - discountAmount;
            }

            OrderItem orderItem = new OrderItem(product.Name, product.Price, quantity,discountAmount, NewPrice);
            orderItems.Add(orderItem);
        }

        public bool DeleteItem(string product) {
            int count = orderItems.RemoveAll(name => name.Name == product);
            return count > 0;
        }

        public int CalculateOrderTotal()
        {
            return orderItems.Count;
        }

        public void PrintItems(string discount) {
            Console.WriteLine($"\nAll items in order {discount}:\n");
            foreach (OrderItem item in orderItems) {
                Console.WriteLine($"Name = {item.Name}  Price = {item.Price} Quantity = {item.Quantity}");
            }
        }
    }
}
