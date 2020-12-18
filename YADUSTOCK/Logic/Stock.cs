using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Stock
    {
        private Product[] stock;

        public Stock(Product[] p)
        {
            this.stock = p;
        }

        public Product[] Stock1
        {
            get
            {
                return stock;
            }
        }

        public void ModifyStock(Product[] stock)
        {
            this.stock = stock;
        }
    }
}
