using System.Collections.Generic;

namespace PizzaSoft.Plugins
{
    public interface IPizza
    {
        string Size { get; set; }
        string Dough { get; set; }
        IEnumerable<string> Toppings { get; set; }

        string PizzaDescription { get; }
    }
}