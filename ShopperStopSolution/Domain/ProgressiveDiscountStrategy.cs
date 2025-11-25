namespace ShopperStopSolution.Domain
{
    public abstract class ProgressiveDiscountStrategy : IDiscountStrategy
    {
        protected abstract List<DiscountSlab> Slabs { get; }

        public decimal GetDiscount(decimal amount)
        {
            decimal discount = 0;

            foreach (DiscountSlab slab in Slabs)
            {
                if (amount > slab.From)
                {
                    decimal slabAmount = decimal.Min(amount, slab.To) - slab.From;
                    if (slabAmount > 0)
                    {
                        discount += slabAmount * slab.Rate;
                    }
                }
            }

            return discount;
        }
    }
}
