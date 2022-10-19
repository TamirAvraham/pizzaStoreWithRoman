using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBackEnd
{
    public class Topping
    {
        public string Name{ get; set; }
        public uint Amount { get; set; }
        public float Location { get; set; }
        public float Price { get; set; }
        public Topping(string name, uint amount, float location, float price)
        {
            Name = name;
            Amount = amount;
            Location = location;
            Price = price;
        }
    }
}
