using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaSoft.Plugins
{
    public abstract class Plugin : IPlugin
    {
        public virtual IEnumerable<IPizzaCreationStep> ChangePizzaCreationSteps(IEnumerable<IPizzaCreationStep> steps)
        {
            return steps;
        }

        public virtual IPizzaPriceCalculator ChangePizzaPriceCalculator(IPizzaPriceCalculator calculator)
        {
            return calculator;
        }
    }
}
