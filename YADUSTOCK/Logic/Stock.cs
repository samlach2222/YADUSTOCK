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
            this.Stock1 = p;
        }

        public List<Product> Stock1 { get => stock; set => stock = value; }

        public void ModifyStock(List<Product> stock)
        {
            this.Stock1 = stock;
        }
    }

}