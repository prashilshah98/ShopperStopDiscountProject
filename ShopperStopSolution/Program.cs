//
using ShopperStopSolution.Services;

namespace ShopperStopSolution
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.Write("Enter customer type (silver / gold / platinum): ");
            string customerType = Console.ReadLine() ?? string.Empty;

            Console.Write("Enter bill amount: ");
            string? amountText = Console.ReadLine();

            if (!decimal.TryParse(amountText, out decimal amount) || amount < 0)
            {
                Console.WriteLine("Invalid amount.");
                return;
            }

            try
            {
                Domain.DiscountStrategyFactory factory = new();
                IBillingService billingService = new BillingService(factory);

                BillResult result = billingService.CalculateBill(customerType, amount);

                Console.WriteLine();
                Console.WriteLine($"Customer Type : {result.CustomerType}");
                Console.WriteLine($"Original Amount : {result.OriginalAmount}");
                Console.WriteLine($"Discount : {result.DiscountAmount}");
                Console.WriteLine($"Final Amount : {result.FinalAmount}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to exit");
            _ = Console.ReadKey();
        }
    }
}
