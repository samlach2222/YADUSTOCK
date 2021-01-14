using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Logic
{
    [DataContract]
    public class Stock
    {
        [DataMember] private List<Product> stock;
        public List<Product> StockPlay { get => stock; set => stock = value; }
        public Stock(List<Product> p)
        {
            this.stock = p;
        }

        public void ModifyStock(List<Product> Nstock)
        {
            for(int i = 0; i < stock.Count; i++)
            {
                stock[i].Quantity += Nstock[i].Quantity;
            }
        }
    }

}