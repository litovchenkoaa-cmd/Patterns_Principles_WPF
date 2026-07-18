using SOLID_Fundamentals;
using System.Globalization;
namespace SOLID_Fundamentals.App
{

    public static class ConsoleOutput
    {
        public static void Output(WithdrawalResult withdrawalResult, decimal amount)
        {
            if (withdrawalResult.IsSuccess)
            {
                Console.WriteLine($"Successfully withdrew {amount}");
            }
            else
            {
                Console.WriteLine($"Withdrawal failed: {withdrawalResult.Message}");
            }
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            var bank = new Bank();
            var fixedDepositAccount = new FixedDepositAccount(new DateTime(2026, 6, 10));
            
            
            ConsoleOutput.Output(bank.ProcessWithdrawal(fixedDepositAccount, 1000m), 1000m);


            /*new List<IShippingStrategy> { new StandartShippingStrategy(), new ExpressShippingStrategy(),
                new OvernightShippingStrategy(), new InternationalShippingStrategy()}*/
            /*new List<IDiscountStrategy> { new RegularDiscountStrategy(), new PremiumDiscountStrategy(), new VIPDiscountStrategy(), 
            new StudentDiscountStrategy(), new SeniorDiscountStrategy()}*/

            var discountCalculator = new DiscountCalculator(new List<IDiscountStrategy> { new RegularDiscountStrategy(), new PremiumDiscountStrategy(), 
                new VIPDiscountStrategy(), new StudentDiscountStrategy(), new SeniorDiscountStrategy()}, 
                new List<IShippingStrategy> { new StandartShippingStrategy(), 
                new ExpressShippingStrategy(), new OvernightShippingStrategy(), new InternationalShippingStrategy()});

            Console.WriteLine(discountCalculator.CalculateDiscount("Student", 6000m));
            Console.WriteLine(discountCalculator.CalculateShippingCost("International", 20.00m, "USA"));

        }
    }
}