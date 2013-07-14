
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaSoft.Plugins;

namespace Clients.BigAl
{
    public class BigAlPlugin : Plugin
    {
        public override IEnumerable<IPizzaCreationStep> ChangePizzaCreationSteps(IEnumerable<IPizzaCreationStep> steps)
        {
            foreach (var pizzaCreationStep in steps)
            {
                if (pizzaCreationStep.StepName != "Price")
                {
                    yield return pizzaCreationStep;
                }
                else
                {
                    yield return new SalesTaxPizzaStep(pizzaCreationStep);
                }
            }
        }

        public override IPizzaPriceCalculator ChangePizzaPriceCalculator(IPizzaPriceCalculator calculator)
        {
            return new SalesTaxCalculator(calculator);
        }
    }
}
