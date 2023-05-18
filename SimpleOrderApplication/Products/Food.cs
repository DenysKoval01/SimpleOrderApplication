using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleOrderApplication.Products
{
    public class Food : Product
    {

        public DateTime ShelfDate { get; }

        public Food(string name, decimal price, DateTime shelfDate) : base(name, price)
        {
            ShelfDate = shelfDate;
        }

        public Food(string name, decimal price) : this(name, price, DateTime.Now.AddDays(5))
        {
        }

        public override string ToString()
        {
            return $"{GetType().Name}: Name={Name}, Price={Price}, ShelfDate={ShelfDate.ToShortDateString()}";
        }
    }
}
