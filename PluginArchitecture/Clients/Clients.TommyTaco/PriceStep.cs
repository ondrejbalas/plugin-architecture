using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaSoft.Plugins;

namespace Clients.TommyTaco
{
    class PriceStep : IPizzaCreationStep
    {
        public string GetDetailsHtml(PizzaState pizzaState)
        {
            return "";
        }

        public bool Validate(PizzaStepResult result)
        {
            return true;
        }

        public string ValidationErrorMessage(PizzaStepResult result)
        {
            return "";
        }

        public string StepName { get { return "Price"; } }
        public string StepHeaderText { get { return "Every Tommy Taco is $1.50"; } }
        public IEnumerable<string> Options { get { yield break; } }
        public bool CanSelectMultiple { get { return false; } }
    }
}
