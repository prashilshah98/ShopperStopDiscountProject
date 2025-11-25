using ShopperStopSolution.Domain;

namespace ShopperStopSolution.Services
{
    public class BillingService : IBillingService
    {
        private readonly IDiscountStrategyFactory _discountStrategyFactory;

        public BillingService(IDiscountStrategyFactory discountStrategyFactory)
        {
            _discountStrategyFactory = discountStrategyFactory;
        }

        public BillResult CalculateBill(string customerType, decimal amount)
        {
            IDiscountStrategy strategy = _discountStrategyFactory.GetStrategy(customerType);
            decimal discount = strategy.GetDiscount(amount);
            decimal finalAmount = amount - discount;

            return new BillResult
            {
                CustomerType = customerType,
                OriginalAmount = amount,
                DiscountAmount = discount,
                FinalAmount = finalAmount
            };
        }
    }
}
