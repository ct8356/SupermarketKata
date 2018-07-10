using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketKata
{
    public class XForYDiscount : ADiscount
    {
        
        private int amountNeeded;
        private decimal newPrice;

        public XForYDiscount(int productID, int amountNeeded, decimal newPrice):base(productID)
        {
            this.amountNeeded = amountNeeded;
            this.newPrice = newPrice;
        }

        public int GetAmountNeeded()
        {
            return amountNeeded;
        }
        
        private decimal GetNewPrice()
        {
            return newPrice;
        }

        override public decimal GetDeduction(int AmountOfEleg, decimal PriceOfEleg)
        {
            decimal PriceWithoutDiscount = PriceOfEleg * AmountOfEleg;

            int amountAtOrigionalPrice = AmountOfEleg % GetAmountNeeded();
            decimal originalPrice = PriceOfEleg * amountAtOrigionalPrice;

            int amountAtDiscountedPrice = (AmountOfEleg - amountAtOrigionalPrice) / GetAmountNeeded();
            decimal discountedPrice = amountAtDiscountedPrice * GetNewPrice();

            return (PriceWithoutDiscount - (discountedPrice + originalPrice));
        }
    }
}
