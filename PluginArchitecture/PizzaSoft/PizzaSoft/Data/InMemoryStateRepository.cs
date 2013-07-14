using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PizzaSoft.Plugins;

namespace PizzaSoft.Data
{
    public class InMemoryStateRepository : IStateRepository
    {
        private readonly Dictionary<string, PizzaState> stateDictionary;

        public InMemoryStateRepository()
        {
            stateDictionary = new Dictionary<string, PizzaState>();
        }

        public PizzaState Load(string id)
        {
            if (!string.IsNullOrEmpty(id) && stateDictionary.ContainsKey(id))
            {
                return stateDictionary[id];
            }
            return null;
        }

        public void Save(PizzaState pizzaState)
        {
            if (string.IsNullOrEmpty(pizzaState.Id))
            {
                pizzaState.Id = Guid.NewGuid().ToString();
            }

            if (stateDictionary.ContainsKey(pizzaState.Id))
            {
                stateDictionary[pizzaState.Id] = pizzaState;
            }
            else
            {
                stateDictionary.Add(pizzaState.Id, pizzaState);
            }
        }
    }
}