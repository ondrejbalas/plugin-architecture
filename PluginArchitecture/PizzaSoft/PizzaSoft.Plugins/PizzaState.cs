using System.Collections.Generic;

namespace PizzaSoft.Plugins
{
    public class PizzaState
    {
        public string Id { get; set; }
        public IList<PizzaStepResult> StepResults { get; private set; }

        public PizzaState()
        {
            StepResults = new List<PizzaStepResult>();
        }
    }
}