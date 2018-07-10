using System;
using System.Collections;
using NUnit.Framework;

namespace SupermarketKata.UnitTests
{
    [TestFixture]
    public class DiscountCalculatorTests
    {
        SupermarketCheckout checkout;

        public DiscountCalculatorTests()
        {
            checkout = new SupermarketCheckout();
        }

        [Test]
        public void FindAmountOfElegableProduct_AmountOfDiscountables_CorrectAmount()
        {
            checkout.clearCart();
            ArrayList products = new ArrayList();
            ArrayList discounts = new ArrayList();
            products.Add(new Product(1, "Toaster", 11.99m));
            products.Add(new Product(1, "Toaster", 11.99m));
            products.Add(new Product(1, "Toaster", 11.99m));
            products.Add(new Product(2, "Oven", 11.99m));
            DiscountCalculator disCalc = new DiscountCalculator(discounts, products);

            Assert.AreEqual(3, disCalc.FindAmountOfElegableProduct(1));
        }

        [Test]
        public void FindPriceOfElegableProduct_PriceOfDiscountables_CorrectPrice()
        {
            checkout.clearCart();
            ArrayList products = new ArrayList();
            ArrayList discounts = new ArrayList();
            products.Add(new Product(1, "Toaster", 11.99m));
            products.Add(new Product(1, "Toaster", 11.99m));
            products.Add(new Product(1, "Toaster", 11.99m));
            products.Add(new Product(2, "Oven", 11.99m));
            DiscountCalculator disCalc = new DiscountCalculator(discounts, products);

            Assert.AreEqual(11.99, disCalc.FindPriceOfElegibleProduct(1));
        }

        [Test]
        public void calculateTotal_TotalWithNoDiscounts_TotalIsCorrect()
        {
            checkout.clearCart();
            ArrayList products = new ArrayList();
            ArrayList discounts = new ArrayList();
            products.Add(new Product(1, "Toaster", 11.99m));
            products.Add(new Product(1, "Toaster", 11.99m));
            products.Add(new Product(1, "Toaster", 11.99m));
            products.Add(new Product(2, "Oven", 11.99m));

            DiscountCalculator disCalc = new DiscountCalculator(discounts, products);

            Assert.AreEqual(47.96, disCalc.calculateTotal());

        }
        public void calculateTotal_TotalWithDiscounts_TotalIsCorrect()
        {
            checkout.clearCart();
            ArrayList products = new ArrayList();
            ArrayList discounts = new ArrayList();
            products.Add(new Product(1, "Toaster", 11.99m));
            products.Add(new Product(1, "Toaster", 11.99m));
            products.Add(new Product(1, "Toaster", 11.99m));
            products.Add(new Product(2, "Oven", 11.99m));

            discounts.Add(new XForYDiscount(1, 3, 23.98m));

            DiscountCalculator disCalc = new DiscountCalculator(discounts, products);

            Assert.AreEqual(35.97, disCalc.calculateTotal());

        }
    }
}
