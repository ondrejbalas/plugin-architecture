using System.Collections.Generic;

namespace PizzaSoft.Plugins
{
    public interface IPizzaCreationStep
    {
        string StepName { get; }
        string StepHeaderText { get; }
        string GetDetailsHtml(PizzaState pizzaState);
        IEnumerable<string> Options { get; }
        bool CanSelectMultiple { get; }
        bool Validate(PizzaStepResult result);
        string ValidationErrorMessage(PizzaStepResult result);
    }
}