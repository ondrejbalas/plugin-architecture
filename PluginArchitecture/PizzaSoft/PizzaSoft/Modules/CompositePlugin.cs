using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PizzaSoft.Plugins;

namespace PizzaSoft.Modules
{
    public class CompositePlugin : IPlugin
    {
        private readonly IEnumerable<IPlugin> plugins;

        public CompositePlugin(IEnumerable<IPlugin> plugins)
        {
            this.plugins = plugins;
        }

        public IEnumerable<IPizzaCreationStep> ChangePizzaCreationSteps(IEnumerable<IPizzaCreationStep> steps)
        {
            IEnumerable<IPizzaCreationStep> result = steps;
            foreach (IPlugin plugin in plugins)
                result = plugin.ChangePizzaCreationSteps(result);
            return result;
        }

        public IPizzaPriceCalculator ChangePizzaPriceCalculator(IPizzaPriceCalculator calculator)
        {
            IPizzaPriceCalculator result = calculator;
            foreach (IPlugin plugin in plugins)
                result = plugin.ChangePizzaPriceCalculator(result);
            return result;
        }
    }
}