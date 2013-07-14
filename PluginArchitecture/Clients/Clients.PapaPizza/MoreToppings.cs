using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaSoft.Plugins;

namespace Clients.PapaPizza
{
    public class MoreToppings : Plugin
    {
        public override IEnumerable<IPizzaCreationStep> ChangePizzaCreationSteps(IEnumerable<IPizzaCreationStep> steps)
        {
            foreach (var step in steps)
            {
                if (step.StepName == "Toppings")
                {
                    yield return new NewToppingsStep(step);
                }
                else
                {
                    yield return step;
                }
            }
        }
    }
}
