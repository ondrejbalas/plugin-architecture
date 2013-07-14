using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaSoft.Plugins;

namespace Clients.Bob
{
    class AllCats : IPizzaCreationStep
    {
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

        public string StepName { get { return "AllCats"; } }
        public string StepHeaderText { get { return "All cats should have a funny mustache"; } }
        public IEnumerable<string> Options { get { yield return "Accept mustache"; } }
        public bool CanSelectMultiple { get { return false; } }
    }
}
