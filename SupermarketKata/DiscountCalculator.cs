using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketKata
{
    public class DiscountCalculator
    {

        ArrayList discounts;
        ArrayList products;
        public DiscountCalculator(ArrayList discounts, ArrayList products) { this.discounts = discounts;
            this.products = products;
        }

        public decimal calculateTotal()
        {
            decimal total = 0;
            //calculate the origional total for everthing, no discounts applied
            foreach (Product product in products)
            {
                total += product.GetPrice();
            }

            //substract the discounts off the total price
            total -= calculateDiscountDeductions();
            return total;

        }

        public decimal calculateDiscountDeductions()
        {
            decimal totalDiscount = 0;
            decimal PriceOfEleg = 0;
            int AmountOfEleg = 0; 
            foreach (ADiscount discount in discounts)
            {
                PriceOfEleg = FindPriceOfElegibleProduct(discount.GetProductID());
                AmountOfEleg = FindAmountOfElegableProduct(discount.GetProductID());
                totalDiscount += discount.GetDeduction(AmountOfEleg, PriceOfEleg);
            }
            return totalDiscount;
        }


        public decimal FindPriceOfElegibleProduct(int productID)
        {
            decimal price = 0;
            foreach (Product product in products)
            {
                if (product.GetID() == productID)
                {
                    price = product.GetPrice();
                }
            }

            return price;
        }
        public int FindAmountOfElegableProduct(int productID)
        {
            int amount = 0;
            foreach(Product product in products)
            {
                if(product.GetID() == productID)
                {
                    amount++;
                }
            }
            return amount;
        }
    }
}
