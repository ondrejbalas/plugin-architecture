using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaSoft.Plugins;

namespace PizzaSoft.Domain
{
    public class DefaultPriceCalculator : IPizzaPriceCalculator
    {
        public decimal CalculatePrice(IPizza basicPizza)
        {
            decimal price = 0M;
            if (basicPizza.Size == "Small") price = 4.95M;
            else if (basicPizza.Size == "Medium") price = 7.95M;
            else if (basicPizza.Size == "Large") price = 9.95M;

            if (basicPizza.Dough == "Wheat") price += 1M;

            price += basicPizza.Toppings.Count();

            return price;
        }
    }
}
