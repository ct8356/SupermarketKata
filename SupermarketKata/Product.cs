using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketKata
{
    public class Product
    {
        protected int prodID;
        protected string name;
        protected decimal price;


        public Product(int ID, string name, decimal price)
        {
            this.prodID = ID;
            this.name = name;
            this.price = price;
        }

        public int GetID()
        {
            return prodID;
        }
        public string GetName()
        {
            return name;
        }

        public decimal GetPrice()
        {
            return price;
        }

    }
}
