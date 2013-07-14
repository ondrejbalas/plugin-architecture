using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaSoft.Domain.Abstract;
using PizzaSoft.Domain.Steps;
using PizzaSoft.Plugins;

namespace PizzaSoft.Domain
{
    public class DefaultPizzaCreationProcess : IPizzaCreationProcess
    {
        private readonly IBinder binder;
        private readonly IPlugin plugin;

        public DefaultPizzaCreationProcess(IBinder binder, IPlugin plugin)
        {
            this.binder = binder;
            this.plugin = plugin;
        }

        public IEnumerable<IPizzaCreationStep> GetStepsInProcess()
        {
            return plugin.ChangePizzaCreationSteps(GetDefaultStepsInProcess());
        }

        private IEnumerable<IPizzaCreationStep> GetDefaultStepsInProcess()
        {
            yield return binder.GetStep<SizeStep>();
            yield return binder.GetStep<DoughStep>();
            yield return binder.GetStep<ToppingsStep>();
            yield return binder.GetStep<PriceStep>();
        }
    }
}
