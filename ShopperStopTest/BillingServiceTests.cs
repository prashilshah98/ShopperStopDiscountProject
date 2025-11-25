using Moq;
using ShopperStopSolution.Domain;
using ShopperStopSolution.Services;

namespace ShopperStopTest
{
    public class BillingServiceTests
    {
        [Fact]
        public void CalculateBill_GoldCustomer_12000_ReturnsCorrectValues()
        {
            Mock<IDiscountStrategyFactory> factoryMock = new();
            GoldDiscountStrategy strategy = new();

            _ = factoryMock
                .Setup(f => f.GetStrategy("gold"))
                .Returns(strategy);

            BillingService service = new(factoryMock.Object);

            BillResult result = service.CalculateBill("gold", 12000m);

            // Expected:
            // 0–5000 @5%   = 250
            // 5000–10000 @10% = 500
            // 10000–12000 @15% = 300
            // Total discount = 1050, final = 10950

            Assert.Equal("gold", result.CustomerType);
            Assert.Equal(12000m, result.OriginalAmount);
            Assert.Equal(1050m, result.DiscountAmount);
            Assert.Equal(10950m, result.FinalAmount);
        }

        [Fact]
        public void CalculateBill_SilverCustomer_8000_ReturnsCorrectValues()
        {
            Mock<IDiscountStrategyFactory> factoryMock = new();
            SilverDiscountStrategy strategy = new();

            _ = factoryMock
                .Setup(f => f.GetStrategy("silver"))
                .Returns(strategy);

            BillingService service = new(factoryMock.Object);

            // Silver slabs:
            // 0–5000 @0% = 0
            // 5000–8000 @5% = 3000 * 0.05 = 150
            // discount=150, final=7850

            BillResult result = service.CalculateBill("silver", 8000m);

            Assert.Equal(8000m, result.OriginalAmount);
            Assert.Equal(150m, result.DiscountAmount);
            Assert.Equal(7850m, result.FinalAmount);
        }

        [Fact]
        public void CalculateBill_InvalidCustomer_Throws()
        {
            Mock<IDiscountStrategyFactory> factoryMock = new();

            _ = factoryMock
                .Setup(f => f.GetStrategy("invalid"))
                .Throws(new ArgumentException("Invalid customer type."));

            BillingService service = new(factoryMock.Object);

            _ = Assert.Throws<ArgumentException>(() => service.CalculateBill("invalid", 5000m));
        }
    }
}


