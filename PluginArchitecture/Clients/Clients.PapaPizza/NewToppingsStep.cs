using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaSoft.Plugins;

namespace Clients.PapaPizza
{
    class NewToppingsStep : IPizzaCreationStep
    {
        private readonly IPizzaCreationStep replacedStep;

        public NewToppingsStep(IPizzaCreationStep replacedStep)
        {
            this.replacedStep = replacedStep;
        }

        public string GetDetailsHtml(PizzaState pizzaState)
        {
            return replacedStep.GetDetailsHtml(pizzaState);
        }

        public bool Validate(PizzaStepResult result)
        {
            return replacedStep.Validate(result);
        }

        public string ValidationErrorMessage(PizzaStepResult result)
        {
            return replacedStep.ValidationErrorMessage(result);
        }

        public string StepName { get { return replacedStep.StepName; } }
        public string StepHeaderText { get { return replacedStep.StepHeaderText; } }

        public IEnumerable<string> Options
        {
            get
            {
                yield return "Saucy Sauce";
                yield return "Cheesy Cheese";
                yield return "Papa's Pepperoni";
                yield return "Bombastic Bacon";
                yield return "Chunky Chicken";
                yield return "Savory Shrimp";
                yield return "Organic Onions";
                yield return "Great Green Peppers";
                yield return "Marvelous Mushrooms";
                yield return "Perfect Pineapple";
            }
        }

        public bool CanSelectMultiple { get { return replacedStep.CanSelectMultiple; } }
    }
}
