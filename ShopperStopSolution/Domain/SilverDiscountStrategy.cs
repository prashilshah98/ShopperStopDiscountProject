namespace ShopperStopSolution.Domain
{
    public class SilverDiscountStrategy : ProgressiveDiscountStrategy
    {
        protected override List<DiscountSlab> Slabs =>
        [
            new DiscountSlab { From = 0,      To = 5000,            Rate = 0.00m },
            new DiscountSlab { From = 5000,   To = 10000,           Rate = 0.05m },
            new DiscountSlab { From = 10000,  To = decimal.MaxValue, Rate = 0.10m }
        ];
    }
}
