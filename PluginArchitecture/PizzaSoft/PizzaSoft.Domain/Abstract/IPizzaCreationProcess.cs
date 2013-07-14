using System.Collections.Generic;
using PizzaSoft.Plugins;

namespace PizzaSoft.Domain.Abstract
{
    public interface IPizzaCreationProcess
    {
        IEnumerable<IPizzaCreationStep> GetStepsInProcess();
    }
}