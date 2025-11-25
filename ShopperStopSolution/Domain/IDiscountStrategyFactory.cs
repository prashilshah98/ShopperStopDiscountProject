namespace ShopperStopSolution.Domain
{
    public interface IDiscountStrategyFactory
    {
        IDiscountStrategy GetStrategy(string customerType);
    }
}
