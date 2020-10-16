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
        private int quantity;

        public Product(TypeProduct n, double price)
        {
            this.quantity = 0;
            // A CODER
        }

        public TypeProduct Name => name;
        public double AtBuyPrice => atBuyPrice;
        public double ResalePrice { get => resalePrice; set => resalePrice = value; }
        public int Quantity { get => quantity; set => quantity = value; }

        public Product[] CreateListProduct()
        {
            // A CODER
            throw new NotImplementedException();
        }
    }
}
