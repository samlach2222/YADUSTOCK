using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Product : CreateProduct
    {
        private readonly TypeProduct name;
        private readonly double atBuyPrice;
        private double resalePrice;
        private float quantity;

        public Product(TypeProduct n, double price, float quantity)
        {
            this.resalePrice = 0;
            this.name = n;
            this.atBuyPrice = price;
            this.quantity = quantity;
        }

        public TypeProduct Name => name;
        public double AtBuyPrice => atBuyPrice;
        public double ResalePrice { get => resalePrice; set => resalePrice = value; }
        public float Quantity { get => quantity; set => quantity = value; }

        public List<Product> CreateListProduct()
        {
            List<Product> list = new List<Product>();
            list.Add(this);
            return list;
        }
    }
}
