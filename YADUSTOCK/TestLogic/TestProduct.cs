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
    }
}
