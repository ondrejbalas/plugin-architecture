using System;
using System.Collections.Generic;
using PizzaSoft.Plugins;

namespace Clients.TommyTaco
{
    public class TacoShellTypeStep : IPizzaCreationStep
    {
        public TacoShellTypeStep()
        {
        }

        public string GetDetailsHtml(PizzaState pizzaState)
        {
            return "";
        }

        public bool Validate(PizzaStepResult result)
        {
            return true;
        }

        public string ValidationErrorMessage(PizzaStepResult result)
        {
            return "";
        }

        public string StepName { get { return "TacoShell"; } }
        public string StepHeaderText { get { return "Let's make a Taco!"; } }
        public IEnumerable<string> Options
        {
            get
            {
                yield return "Soft Shell";
                yield return "Hard Shell";
            }
        }

        public bool CanSelectMultiple { get { return false; } }
    }
}