using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Market
    {
        private readonly List<LateDelivery>lateDelivery;

        public List<LateDelivery> LateDelivery => lateDelivery;

        public Market()
        {
            lateDelivery = new List<LateDelivery>();
        }

        public Product Purchase(Product p, int quantity)
        {
            Random aleatoire = new Random();
            int test = aleatoire.Next(1,4);
            if (test == 1)
            {
                LateDelivery late = new LateDelivery(p.Name, quantity, aleatoire.Next(2, 5));
                this.lateDelivery.Add(late);
            }
            else
            {
                p.Quantity = p.Quantity + quantity;
            }
            return p;
        }

        public Boost PurchaseBoost(Boost b)
        {
            b.Etat = true;
            return b;
        }

        public Product IsDelivery(Product p)
        {
            foreach (LateDelivery late in lateDelivery){
                if ((p.Name == late.Product) && (late.TurnAfterDelivery == 0));
                {
                    p.Quantity = late.Quantity;
                }
            }
            return p;
        }
    }
}
