using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleOrderApplication.Products
{
    public class Book : Product
    {

        public string Author { get; set; }  
        public Book(string name, decimal price, string author) : base(name, price)
        {
            Author = author;
        }

        public Book(string name, decimal price) : this(name, price, "No Author")
        {
        }

       public override string ToString()
        {
            return $"{GetType().Name}: Name={Name}, Price={Price}, Author={Author}";
        }


    }
}
