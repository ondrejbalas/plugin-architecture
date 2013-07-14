using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaSoft.Plugins;

namespace PizzaSoft.Domain
{
    public class BasicPizza : IPizza
    {
        public string PizzaDescription { get; set; }

        public string Size { get; set; }
        public string Dough { get; set; }
        public IEnumerable<string> Toppings { get; set; }

        public override string ToString()
        {
            return PizzaDescription;
        }
    }
}
