using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleOrderApplication.Products
{
    public abstract class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        public Product(string NameProduct,decimal PriceProduct) 
        {
            if(PriceProduct < 0) throw new ArgumentException("The price should be positive!");
            Name = NameProduct;
            Price = PriceProduct;
        }

        public override string ToString() { return "You never should see this! :)"; }
    }
}
