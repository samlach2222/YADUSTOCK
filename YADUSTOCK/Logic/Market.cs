using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Logic
{
    [DataContract]
    public class Market
    {
        [DataMember] private readonly List<LateDelivery>lateDelivery;

        public List<LateDelivery> LateDelivery => lateDelivery;
        /// <summary>
        /// constructeur de la classe
        /// </summary>
        public Market()
        {
            lateDelivery = new List<LateDelivery>();
        }

        /// <summary>
        /// permet d'acheter un produit
        /// </summary>
        /// <param name="p">nom du produit à acheter</param>
        /// <returns></returns>
        public Product Purchase(Product p)
        {
            Random aleatoire = new Random();
            int test = aleatoire.Next(1,4);
            if (test == 1)
            {
                LateDelivery late = new LateDelivery(p.Name, p.QuantityToBuy, aleatoire.Next(2, 5));
                this.lateDelivery.Add(late);
            }
            else
            {
                p.Quantity = p.QuantityToBuy;
            }
            return p;
        }

        /// <summary>
        /// Permet d'acheter un boost
        /// </summary>
        /// <param name="b">Type du boost à acheter</param>
        /// <returns></returns>
        public Boost PurchaseBoost(Boost b)
        {
            b.Etat = true;
            return b;
        }

        /// <summary>
        /// permet de verifier si un produit est livré
        /// </summary>
        /// <param name="p">Type du produit en retard</param>
        /// <returns></returns>
        public Product IsDelivery(Product p)
        {
            foreach (LateDelivery late in lateDelivery){
                if ((p.Name == late.Product) && (late.TurnAfterDelivery == 0));
                {
                    p.Quantity += late.Quantity;
                }
            }
            return p;
        }
    }
}
