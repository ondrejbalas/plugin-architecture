using System.Collections.Generic;

namespace PizzaSoft.Plugins
{
    public class PizzaStepResult
    {
        public string StepName { get; set; }
        public bool StepComplete { get; set; }
        public List<string> SelectedOptions { get; private set; }

        public PizzaStepResult()
        {
            SelectedOptions = new List<string>();
        }
    }
}