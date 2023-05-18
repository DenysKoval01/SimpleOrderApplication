using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleOrderApplication.Products
{
    public class Electronics : Product
    {
        public Electronics(string Name, decimal Price) : base(Name, Price)
        {
        }

        public override string ToString()
        {
            return $"{GetType().Name}: Name={Name}, Price={Price}";
        }
    }
}
