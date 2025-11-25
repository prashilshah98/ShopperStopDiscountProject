namespace ShopperStopSolution.Domain
{
    public class DiscountStrategyFactory : IDiscountStrategyFactory
    {
        public IDiscountStrategy GetStrategy(string customerType)
        {
            return string.IsNullOrWhiteSpace(customerType)
                ? throw new ArgumentException("Customer type is required.", nameof(customerType))
                : customerType.Trim().ToLower() switch
                {
                    "silver" => new SilverDiscountStrategy(),
                    "gold" => new GoldDiscountStrategy(),
                    "platinum" => new PlatinumDiscountStrategy(),
                    _ => throw new ArgumentException("Invalid customer type.", nameof(customerType))
                };
        }
    }
}
