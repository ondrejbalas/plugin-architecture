namespace PizzaSoft.Plugins
{
    public interface IPizzaPriceCalculator
    {
        decimal CalculatePrice(IPizza pizza);
    }
}