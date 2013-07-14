using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaSoft.Plugins;

namespace Clients.BigAl
{
    public class SalesTaxPizzaStep : IPizzaCreationStep
    {
        private readonly IPizzaCreationStep replacedStep;

        public SalesTaxPizzaStep(IPizzaCreationStep replacedStep)
        {
            this.replacedStep = replacedStep;
        }

        public string StepName { get { return "PriceWithTax"; } }
        public string StepHeaderText { get { return replacedStep.StepHeaderText + " (with tax)"; } }

        public string GetDetailsHtml(PizzaState pizzaState)
        {
            return replacedStep.GetDetailsHtml(pizzaState);
        }

        public IEnumerable<string> Options { get { return replacedStep.Options; } }
        public bool CanSelectMultiple { get { return replacedStep.CanSelectMultiple; } }
        public bool Validate(PizzaStepResult result)
        {
            return replacedStep.Validate(result);
        }

        public string ValidationErrorMessage(PizzaStepResult result)
        {
            return replacedStep.ValidationErrorMessage(result);
        }
    }
}
