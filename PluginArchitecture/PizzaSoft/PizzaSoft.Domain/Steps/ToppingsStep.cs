using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaSoft.Plugins;

namespace PizzaSoft.Domain.Steps
{
    class ToppingsStep : IPizzaCreationStep
    {
        public string StepName { get { return "Toppings"; } }
        public string StepHeaderText { get { return "Which Toppings?"; } }
        public string GetDetailsHtml(PizzaState wizardState)
        {
            return "";
        }

        public IEnumerable<string> Options
        {
            get
            {
                yield return "Cheese";
                yield return "Pepperoni";
                yield return "Ham";
                yield return "Bacon";
                yield return "Peppers";
                yield return "Onion";
                yield return "Mushrooms";
                yield return "Pineapple";
            }
        }

        public bool CanSelectMultiple { get { return true; } }
        public bool Validate(PizzaStepResult result)
        {
            return result.SelectedOptions.Count >= 1;
        }

        public string ValidationErrorMessage(PizzaStepResult result)
        {
            if (result.SelectedOptions.Count == 0) return "You must select at least one topping";
            throw new NotImplementedException();
        }
    }
}
