namespace SOLID_Fundamentals//OCP
{
    public interface IDiscountStrategy
    {
        decimal Calculate(decimal orderAmount);
        bool CanApply(string customerType);
    }

    public class RegularDiscountStrategy : IDiscountStrategy
    {
        public bool CanApply(string customerType) => customerType == "Regular";
        public decimal Calculate(decimal orderAmount) => orderAmount * 0.05m;
    }
    public class PremiumDiscountStrategy : IDiscountStrategy
    {
        public bool CanApply(string customerType) => customerType == "Premium";
        public decimal Calculate(decimal orderAmount) => orderAmount * 0.10m;
    }
    public class VIPDiscountStrategy : IDiscountStrategy
    {
        public bool CanApply(string customerType) => customerType == "VIP";
        public decimal Calculate(decimal orderAmount) => orderAmount * 0.15m;
    }
    public class StudentDiscountStrategy : IDiscountStrategy
    {
        public bool CanApply(string customerType) => customerType == "Student";
        public decimal Calculate(decimal orderAmount) => orderAmount * 0.08m;
    }
    public class SeniorDiscountStrategy : IDiscountStrategy
    {
        public bool CanApply(string customerType) => customerType == "Senior";
        public decimal Calculate(decimal orderAmount) => orderAmount * 0.05m;
    }


    public interface IShippingStrategy
    {
        decimal Calculate(decimal weight, string destination);
        bool CanApply(string shippingMethod);
    }

    public class StandartShippingStrategy : IShippingStrategy
    {
        public bool CanApply(string shippingMethod) => shippingMethod == "Standart";
        public decimal Calculate(decimal weight, string destination) => weight * 0.10m;
    }
    public class ExpressShippingStrategy : IShippingStrategy
    {
        public bool CanApply(string shippingMethod) => shippingMethod == "Express";
        public decimal Calculate(decimal weight, string destination) => weight * 0.15m;
    }
    public class OvernightShippingStrategy : IShippingStrategy
    {
        public bool CanApply(string shippingMethod) => shippingMethod == "Overnight";
        public decimal Calculate(decimal weight, string destination) => weight * 0.08m;
    }

    public class InternationalShippingStrategy : IShippingStrategy
    {
        public bool CanApply(string shippingMethod) => shippingMethod == "International";
        public decimal Calculate(decimal weight, string destination)
        {
            switch (destination)
            {
                case "USA": return 30.00m;
                case "Europe": return 35.00m;
                case "Asia": return 40.00m;
                default: return 50.00m;
            }
        }
    }




    public class DiscountCalculator
    {
        private readonly List<IDiscountStrategy> _discountStrategies;
        private readonly List<IShippingStrategy> _shippingStrategies;

        public DiscountCalculator(List<IDiscountStrategy> discountStrategies, List<IShippingStrategy> shippingStrategies)
        {
            _discountStrategies = discountStrategies ?? new List<IDiscountStrategy> ();

            _shippingStrategies = shippingStrategies ?? new List<IShippingStrategy> ();
        }
        public decimal CalculateDiscount(string customerType, decimal orderAmount)
        {
            foreach (var strategy in _discountStrategies)
            {
                if (strategy.CanApply(customerType))
                {
                    return strategy.Calculate(orderAmount);
                }
            }
            return 0.0m;
        }

        public decimal CalculateShippingCost(string shippingMethod, decimal weight, string destination)
        {
            foreach (var strategy in _shippingStrategies)
            {
                if (strategy.CanApply(shippingMethod))
                {
                    return strategy.Calculate(weight, destination);
                }
            }
            return 0.0m;
        }
    }
}
