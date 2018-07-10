using System;
using System.Collections;
using NUnit.Framework;

namespace SupermarketKata.UnitTests
{
    [TestFixture]
    public class SupermarketCheckoutTests
    {
        SupermarketCheckout checkout;
        

        public SupermarketCheckoutTests()
        {
            checkout = new SupermarketCheckout();
        }

        [Test]
        public void Total_BoughtNothing_TotalIsZero()
        {
            checkout.clearCart();
            Assert.AreEqual(checkout.DiscountedTotal(), 0);
        }

        [Test]
        public void Total_TenItemsAll1Pound_TotalIsTen()
        {
            checkout.clearCart();
            ScanMultipleItems(10, 1, "Toaster", 11.99m);
            


            Assert.AreEqual(checkout.DiscountedTotal(), 10 * 11.99);
        }

        [Test]
        public void Total_TestTotal_PriceIsRight()
        {
            checkout.clearCart();
            checkout.Scan(new Product(1,"Toaster", 11.99m));
            checkout.Scan(new Product(2,"Kettle", 20.99m));
            checkout.Scan(new Product(3,"Oven", 12.99m));

            Assert.AreEqual(checkout.DiscountedTotal(), 45.97);
        }

        [Test] public void Total_TestXForYDiscount_DiscountApplied()
        {
            checkout.clearCart();
            ScanMultipleItems(3, 1, "Toaster", 11.99m);
            
            checkout.addNewDiscountedItem(1, 3, 23.98m);

            Assert.AreEqual(checkout.DiscountedTotal(), 23.98);
        }


        [Test]
        public void Total_TestXForYDiscountMultipleItems_DiscountApplied()
        {
            checkout.clearCart();
            ScanMultipleItems(3, 1, "Toaster", 11.99m);
            ScanMultipleItems(5, 2, "Oven", 11.99m);

            checkout.addNewDiscountedItem(1, 3, 23.98m);
            checkout.addNewDiscountedItem(2, 4, 6.00m);

            Assert.AreEqual(checkout.DiscountedTotal(), 41.97);
        }

        [Test]
        public void Total_TestXForYDiscountTwoTimes_DiscountApplied()
        {
            checkout.clearCart();
            ScanMultipleItems(8, 1, "Toaster", 11.99m);
            ScanMultipleItems(2, 2, "Oven", 11.99m);
            

            checkout.addNewDiscountedItem(1, 3, 23.98m);
            checkout.addNewDiscountedItem(2, 4, 6.00m);

            Assert.AreEqual(checkout.DiscountedTotal(), 95.92);
        }

        public void ScanMultipleItems(int amount, int productID, string productName, decimal productPrice)
        {
            for(int i = 0; i < amount; i++)
            {
                checkout.Scan(new Product(productID, productName, productPrice));
            }
        }
    }
}
