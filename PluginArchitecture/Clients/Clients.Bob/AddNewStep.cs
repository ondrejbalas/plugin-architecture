using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaSoft.Plugins;

namespace Clients.Bob
{
    public class AddNewStep : Plugin
    {
        public override IEnumerable<IPizzaCreationStep> ChangePizzaCreationSteps(IEnumerable<IPizzaCreationStep> steps)
        {
            var list = steps.ToList();
            list.Insert(2, new AllCats());
            return list;
        }
    }
}
