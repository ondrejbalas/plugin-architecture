using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaSoft.Plugins;

namespace Clients.BigAl
{
    class SalesTaxCalculator : IPizzaPriceCalculator
    {
        private readonly IPizzaPriceCalculator replacedCalculator;

        public SalesTaxCalculator(IPizzaPriceCalculator replacedCalculator)
        {
            this.replacedCalculator = replacedCalculator;
        }

        public decimal CalculatePrice(IPizza pizza)
        {
            return replacedCalculator.CalculatePrice(pizza) * 1.06M;
        }
    }
}
