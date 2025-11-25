namespace ShopperStopSolution.Services
{
    public interface IBillingService
    {
        BillResult CalculateBill(string customerType, decimal amount);
    }

    public class BillResult
    {
        public string CustomerType { get; set; } = string.Empty;
        public decimal OriginalAmount { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal FinalAmount { get; set; }
    }
}
