using PizzaSoft.Plugins;

namespace PizzaSoft.Domain.Abstract
{
    public interface IBinder
    {
        IPizzaCreationStep GetStep<T>()
            where T : IPizzaCreationStep;
    }
}