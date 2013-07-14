using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaSoft.Plugins;

namespace Clients.TommyTaco
{
    public class TacoStand : Plugin
    {
        public override IEnumerable<IPizzaCreationStep> ChangePizzaCreationSteps(IEnumerable<IPizzaCreationStep> steps)
        {
            yield return new TacoShellTypeStep();
            yield return new PriceStep();
        }
    }
}
