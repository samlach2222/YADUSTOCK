using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Logic;
using Xunit;

namespace TestLogic
{
    public class TestMarket
    {
        [Fact]
        public void TestPurchase()
        {
            Market m = new Market();
            Product p = new Product(TypeProduct.TAROT, 15, 0);
            p = m.Purchase(p, 100);

            if((m.LateDelivery == null)&&(m.LateDelivery.Any()))
            {
                Assert.NotEmpty(m.LateDelivery);
            }
            else
            {
               Assert.Equal(100, p.Quantity); 
            }
            
            
        }

        [Fact]
        public void TestPurchaseBoost()
        {
            Market m = new Market();
            Boost p = new Boost(TypeBoost.PUB,12.2,12);
            p = m.PurchaseBoost(p);

            Assert.True(p.Etat);
        }
    }
}
