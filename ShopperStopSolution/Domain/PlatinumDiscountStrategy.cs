namespace ShopperStopSolution.Domain
{
    public class PlatinumDiscountStrategy : ProgressiveDiscountStrategy
    {
        protected override List<DiscountSlab> Slabs =>
        [
            new DiscountSlab { From = 0,      To = 3000,            Rate = 0.05m },
            new DiscountSlab { From = 3000,   To = 8000,            Rate = 0.10m },
            new DiscountSlab { From = 8000,   To = 12000,           Rate = 0.15m },
            new DiscountSlab { From = 12000,  To = decimal.MaxValue, Rate = 0.20m }
        ];
    }
}
