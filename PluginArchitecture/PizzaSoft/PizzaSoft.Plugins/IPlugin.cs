using System.Collections.Generic;

namespace PizzaSoft.Plugins
{
    public interface IPlugin
    {
        IEnumerable<IPizzaCreationStep> ChangePizzaCreationSteps(IEnumerable<IPizzaCreationStep> steps);
        IPizzaPriceCalculator ChangePizzaPriceCalculator(IPizzaPriceCalculator calculator);
    }
}