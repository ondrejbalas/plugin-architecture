using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaSoft.Domain.Abstract;
using PizzaSoft.Plugins;

namespace PizzaSoft.Domain.Steps
{
    public class PriceStep : IPizzaCreationStep
    {
        private readonly IPizzaPriceCalculator priceCalculator;
        private readonly IPizzaFactory pizzaFactory;

        public PriceStep(IPizzaPriceCalculator priceCalculator, IPizzaFactory pizzaFactory)
        {
            this.priceCalculator = priceCalculator;
            this.pizzaFactory = pizzaFactory;
        }

        public string StepName { get { return "Price"; } }
        public string StepHeaderText { get { return "Every pizza has it's price"; } }
        public string GetDetailsHtml(PizzaState wizardState)
        {
            var pizza = pizzaFactory.CreatePizza(wizardState);
            return
                string.Format(
                    "<div>Selected pizza: {0}</div><div>Price: <span style=\"font-weight: bold; font-size: larger;\">{1}</span></div>",
                    pizza.PizzaDescription,
                    priceCalculator.CalculatePrice(pizza).ToString("c"));
        }

        public IEnumerable<string> Options { get { yield break; } }
        public bool CanSelectMultiple { get { return false; } }
        public bool Validate(PizzaStepResult result)
        {
            return true;
        }

        public string ValidationErrorMessage(PizzaStepResult result)
        {
            throw new NotImplementedException();
        }
    }
}
