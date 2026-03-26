
    public class PriceCalculator
    {
        private readonly IDiscountStrategy _discountStrategy;

        public PriceCalculator(IDiscountStrategy discountStrategy)
        {
            _discountStrategy = discountStrategy;
        }

        public double CalculateFinalPrice(double amount)
        {
            double discount = _discountStrategy.CalculateDiscount(amount);
            return amount - discount;
        }
    }
