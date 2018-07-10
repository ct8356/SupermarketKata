using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketKata
{
    public class SupermarketCheckout
    {

        ArrayList products;
        ArrayList discounts;
        public SupermarketCheckout()
        {
            products = new ArrayList();
            discounts = new ArrayList();
        }

        public void clearCart()
        {
            products.Clear();
            discounts.Clear();
        }

        public void addNewDiscountedItem(int productID, int amountNeeded, decimal newPrice)
        {
            discounts.Add(new XForYDiscount(productID, amountNeeded, newPrice));
        }
        public void Scan(Product price)
        {
            products.Add(price);
        }
        public decimal DiscountedTotal()
        {
            DiscountCalculator disCalc = new DiscountCalculator(discounts, products);
            return disCalc.calculateTotal();
        }
        public decimal Total()
        {
            decimal total = 0;
            
            foreach (Product product in products)
            {
                total += product.GetPrice();
            }
            return total;
        }
        public void printShoppingList()
        {
            Console.WriteLine("Your Order:");

            foreach(Product product in products)
            {
                Console.WriteLine(product.GetName() + " £" + product.GetPrice());
            }
            Console.WriteLine("Total: £" + Total());
            Console.WriteLine("With Promotions applied: £" + DiscountedTotal());

        }

        static void Main(string[] args)
        {
            SupermarketCheckout checkout = new SupermarketCheckout();

            checkout.clearCart();
            checkout.Scan(new Product(1, "Toaster", 11.99m));
            checkout.Scan(new Product(1, "Toaster", 11.99m));
            checkout.Scan(new Product(1, "Toaster", 11.99m));
            checkout.Scan(new Product(2, "Oven", 11.99m));
            checkout.Scan(new Product(2, "Oven", 11.99m));
            checkout.Scan(new Product(2, "Oven", 11.99m));
            checkout.Scan(new Product(2, "Oven", 11.99m));
            checkout.Scan(new Product(2, "Oven", 11.99m));

            checkout.addNewDiscountedItem(1, 3, 23.98m);
            checkout.addNewDiscountedItem(2, 4, 6.00m);
            checkout.printShoppingList();

            while (true) ;
        }
    }
}
