using PizzaSoft.Plugins;

namespace PizzaSoft.Domain.Abstract
{
    public interface IPizzaFactory
    {
        IPizza CreatePizza(PizzaState pizzaState);
    }
}