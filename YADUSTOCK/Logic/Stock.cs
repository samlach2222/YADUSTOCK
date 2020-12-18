using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Stock
    {
        private List<Product> stock;

        public Stock(List<Product> p)
        {
            this.stock = p;
        }

        public List<Product> getStock
        {
            get
            {
                return stock;
            }
        }

        public void ModifyStock(List<Product> stock)
        {
            this.stock = stock;
        }
    }

}