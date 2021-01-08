using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Logic
{
    [DataContract]
    public class Product
    {
        [DataMember] private readonly TypeProduct name;
        [DataMember] private readonly double atBuyPrice;
        [DataMember] private double resalePrice;
        [DataMember] private double lastPrice;
        [DataMember] private double elasticité;
        [DataMember] private float quantity;

        public Product(TypeProduct n, double price, float quantity, double elasticité)
        {
            this.resalePrice = atBuyPrice;
            this.lastPrice = this.resalePrice;
            this.name = n;
            this.atBuyPrice = price;
            this.quantity = quantity;
            this.elasticité = elasticité;
        }

        public TypeProduct Name => name;
        public double AtBuyPrice => atBuyPrice;
        public double ResalePrice { get => resalePrice; set => resalePrice = value; }
        public double LastPrice { get => lastPrice; set => lastPrice = value; }
        public float Quantity { get => quantity; set => quantity = value; }
        public double Elasticité { get => elasticité; set => elasticité = value; }

    }
}
