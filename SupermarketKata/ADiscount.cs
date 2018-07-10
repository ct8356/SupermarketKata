using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketKata
{
    abstract public class ADiscount
    {
        private int productID;
        public ADiscount(int productID) {
            this.productID = productID;
        }

        public int GetProductID()
        {
            return productID;
        }

        abstract public decimal GetDeduction(int amountOfProduct, decimal productPrice);
    }
}
