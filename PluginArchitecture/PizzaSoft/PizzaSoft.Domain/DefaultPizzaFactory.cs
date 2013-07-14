using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaSoft.Domain.Abstract;
using PizzaSoft.Plugins;

namespace PizzaSoft.Domain
{
    public class DefaultPizzaFactory : IPizzaFactory
    {
        public IPizza CreatePizza(PizzaState pizzaState)
        {
            var size = pizzaState.StepResults.Single(x => x.StepName == "Size").SelectedOptions.Single();
            var dough = pizzaState.StepResults.Single(x => x.StepName == "Dough").SelectedOptions.Single();
            var toppings = pizzaState.StepResults.Single(x => x.StepName == "Toppings").SelectedOptions;

            return new BasicPizza()
                {
                    Size = size,
                    Dough = dough,
                    Toppings = toppings,
                    PizzaDescription = string.Format("{0} Pizza on {1} Dough, and topped with {2}", size, dough, string.Join(", ", toppings))
                };
        }
    }
}
