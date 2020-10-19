using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class LateDelivery : Market
    {
        private TypeProduct product;
        private int quantity;
        private int turnAfterDelivery;

        public LateDelivery(TypeProduct product, int quantity, int tAD)
        {
            // A CODER
            this.quantity = 0;
            this.turnAfterDelivery = 0;
        }

        public TypeProduct Product { get => product; set => product = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public int TurnAfterDelivery { get => turnAfterDelivery; set => turnAfterDelivery = value; }
    }
}
