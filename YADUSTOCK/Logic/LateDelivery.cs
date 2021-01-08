﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Logic
{
    [DataContract]
    public class LateDelivery
    {
        [DataMember] private TypeProduct product;
        [DataMember] private int quantity;
        [DataMember] private int turnAfterDelivery;

        public LateDelivery(TypeProduct product, int quantity, int tAD)
        {
            this.product = product;
            this.quantity = 0;
            this.turnAfterDelivery = 0;
        }

        public TypeProduct Product { get => product; set => product = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public int TurnAfterDelivery { get => turnAfterDelivery; set => turnAfterDelivery = value; }
    }
}
