using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaSoft.Plugins;

namespace PizzaSoft.Domain.Steps
{
    public class DoughStep : IPizzaCreationStep
    {
        public string StepName { get { return "Dough"; } }
        public string StepHeaderText { get { return "What kind of dough?"; } }
        public string GetDetailsHtml(PizzaState wizardState)
        {
            return "";
        }

        public IEnumerable<string> Options
        {
            get
            {
                yield return "Normal";
                yield return "Wheat";
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
