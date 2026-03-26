using System;



    class Program
    {
        static void Main(string[] args)
        {
            double amount = 1000;

          
            IDiscountStrategy discount = new VipCustomerDiscount();

            PriceCalculator calculator = new PriceCalculator(discount);

            double finalPrice = calculator.CalculateFinalPrice(amount);

            Console.WriteLine($"Original Amount: {amount}");
            Console.WriteLine($"Final Price: {finalPrice}");

            Console.ReadLine();
        }
    }
