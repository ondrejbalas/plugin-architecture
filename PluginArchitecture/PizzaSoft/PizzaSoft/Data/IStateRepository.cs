using PizzaSoft.Plugins;

namespace PizzaSoft.Data
{
    public interface IStateRepository
    {
        PizzaState Load(string id);
        void Save(PizzaState pizzaState);
    }
}