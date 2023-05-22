using SimpleOrderApplication.Discounts;
using SimpleOrderApplication.Orders;
using SimpleOrderApplication.Products;

namespace SimpleOrderApplication
{
    public class Program
    {
        private static readonly string WithoutDiscount = "without any Discount";
        private static readonly string WithDiscount = "with Percent Discount";
        private static readonly string WithFixDiscount = "with Fix Discount";
        public static void Main(string[] args)
        {
            //Create some product objects of each product types (Book, Food, Electronics)
            Book book = new Book("Bukvar", 2000.5m, "Ivan Fedorov");
            Food food = new Food("Avokado", 20.5m, DateTime.Now);
            Electronics electronics = new Electronics("NoteBook", 105m);

            //Print the products to the console, check that the appropriate overridden ToString() methods were used
            Console.WriteLine(book);
            Console.WriteLine(food);
            Console.WriteLine(electronics);

            //Create an Order without any Discount and add some items to it

            Order orderWithout = new Order();

            orderWithout.AddItem(book, 30);
            orderWithout.AddItem(food, 50);
            orderWithout.AddItem(book, 10);

            // Print the order with the PrintItems() method
            orderWithout.PrintItems(WithoutDiscount);

            //check the discount is 0 in each item
            foreach (OrderItem item in orderWithout.orderItems)
            {
                Console.WriteLine("Item: " + item.Name + ", Discount: " + item.Discount + ", New Price: " + item.NewPrice);
            }


            // print the total amount of the order to the console with the CalculateOrderTotal() method
            decimal totalAmountWithout = orderWithout.CalculateOrderTotal();
            Console.WriteLine($"Total Amount: {totalAmountWithout}");



            //Order with Percent Discount
            IDiscount discountPer = new PercentDiscount(10);

            Order orderWith = new Order(discountPer);

            orderWith.AddItem(book, 3);
            orderWith.AddItem(food, 5);
            orderWith.AddItem(book, 1);

            // Print the order with the PrintItems() method
            orderWith.PrintItems(WithDiscount);


            //check the discount in each item
            foreach (OrderItem item in orderWith.orderItems)
            {
                Console.WriteLine("Item: " + item.Name + ", Discount: " + item.Discount + ", New Price: " + item.NewPrice);
            }


            // print the total amount of the order to the console with the CalculateOrderTotal() method
            decimal totalAmountWith = orderWith.CalculateOrderTotal();
            Console.WriteLine($"Total Amount: {totalAmountWith}");





            //Order with Fix Discount
            IDiscount discountFix = new FixDiscount(1000);

            Order orderWithFix = new Order(discountFix);

            orderWithFix.AddItem(book, 3);
            orderWithFix.AddItem(food, 5);
            orderWithFix.AddItem(book, 1);

            // Print the order with the PrintItems() method
            orderWithFix.PrintItems(WithFixDiscount);


            //check the Fix discount in each item
            foreach (OrderItem item in orderWithFix.orderItems)
            {
                Console.WriteLine("Item: " + item.Name + ", Discount: " + item.Discount + ", New Price: " + item.NewPrice);
            }


            // print the total amount of the order to the console with the CalculateOrderTotal() method
            decimal totalAmountWithFix = orderWithFix.CalculateOrderTotal();
            Console.WriteLine($"Total Amount: {totalAmountWithFix}");



            OrderItem testdOrderItem = new OrderItem("TestdOrderItem", 15,2, 0,5);
            Console.WriteLine(testdOrderItem);
            testdOrderItem.Discount = 5;
            Console.WriteLine(testdOrderItem);
            testdOrderItem.Quantity = 4;
            Console.WriteLine(testdOrderItem);


            Console.ReadLine();
        }
    }
}