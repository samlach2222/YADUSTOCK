using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Logic;
using Xunit;

namespace TestLogic
{
    public class TestProduct
    {
        [Fact]
        public void TestCreate()
        {
            Product product = new Product(TypeProduct.POKEMON, 2, 6);
            Assert.Equal(TypeProduct.POKEMON, product.Name);
            Assert.Equal(2, product.AtBuyPrice);
            Assert.Equal(6, product.Quantity);
            Assert.Equal(0, product.ResalePrice);
        }

        [Fact]
        public void TestListProduct()
        {
            CreateProduct p = new Product(TypeProduct.POKEMON, 2, 6);
            CreateProduct p2 = new Product(TypeProduct.CARTE, 1, 7);

            List<Product> d = p.CreateListProduct();
            List<Product> d2 = p2.CreateListProduct();

            Assert.NotEmpty(d);
            Assert.NotEmpty(d2);
            Assert.Equal(d.ElementAt(0), p);
            Assert.Equal(d2.ElementAt(0), p2);
        }
    }
}
