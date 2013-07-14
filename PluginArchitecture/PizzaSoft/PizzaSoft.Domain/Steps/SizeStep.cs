using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaSoft.Plugins;

namespace PizzaSoft.Domain.Steps
{
    public class SizeStep : IPizzaCreationStep
    {
        public string StepName { get { return "Size"; } }
        public string StepHeaderText { get { return "Let's make a Pizza!"; } }
        public string GetDetailsHtml(PizzaState wizardState)
        {
            return "";
        }

        public IEnumerable<string> Options
        {
            get
            {
                yield return "Small";
                yield return "Medium";
                yield return "Large";
            }
        }

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
