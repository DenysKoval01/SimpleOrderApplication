using NUnit.Framework;
using SimpleOrderApplication.Discounts;
using SimpleOrderApplication.Orders;
using SimpleOrderApplication.Products;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleOrderApplication.NUnit
{
    [TestFixture]
    public class NunitTests
    {
        [TestCase(35, 5, 30)]
        [TestCase(35, 45, 35)]
        [TestCase(35, 35, 35)]

        public void GetNewPriceWithFixDiscount(decimal originalPrice, decimal fixDiscount,
                                                                                decimal expectedDiscountedPrice)
        {
            decimal OriginalPrice = originalPrice;
            //if (originalPrice > fixDiscount) return fixDiscount; else return price; 
            //after that originalPrice - fixDiscount = expectedDiscountedPrice
            decimal FixDiscount = fixDiscount;
            decimal ExpectedDiscountedPrice = expectedDiscountedPrice;
            Book book = new Book("Test Product", OriginalPrice);

            //apply new discount
            IDiscount discountFix = new FixDiscount(FixDiscount);

            //create Order with discount
            Order order = new Order(discountFix);

            //add new Item to Order
            order.AddItem(book, 3);

            // get actual new Price
            decimal actualDiscountedPrice = order.orderItems[0].NewPrice;

            // Assert
            Assert.AreEqual(actualDiscountedPrice, ExpectedDiscountedPrice);
        }


        [TestCase(35, 10, 31.5)]
        //fail 40-4 !=37
        [TestCase(40, 10, 37)]

        public void GetNewPriceWithPercentDiscount(decimal originalPrice, decimal perDiscount,
                                                                        decimal expectedDiscountedPrice)
        {
            decimal OriginalPrice = originalPrice;

            //return price * (PercentDiscountValue / 100);
            decimal PerDiscount = perDiscount;
            decimal ExpectedDiscountedPrice = expectedDiscountedPrice;
            Electronics electronics = new Electronics("Test Electronics", OriginalPrice);

            //apply new discount
            IDiscount discountPer = new PercentDiscount(PerDiscount);

            //create Order with discount
            Order order = new Order(discountPer);

            //add new Item to Order
            order.AddItem(electronics, 5);

            // get actual new Price
            decimal actualDiscountedPrice = order.orderItems[0].NewPrice;

            // Assert
            Assert.AreEqual(actualDiscountedPrice, ExpectedDiscountedPrice);
        }

        [Test]
        public void GetExeptionWhileAddingNegativeQuantity()
        {
            decimal OriginalPrice = 30m;

            Electronics electronics = new Electronics("Test Electronics", OriginalPrice);


            //create Order with discount
            Order order = new Order();

            //add new Item to Order with negative quantity and try cath exeption
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                order.AddItem(electronics, -5);
            });
        }
    }
}
