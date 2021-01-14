using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Logic
{
    [DataContract]
    public class SaleMarket
    {
        [DataMember] private double ownWin = 0;

        public double OwnWin { get => ownWin; set=> ownWin = value; }

        /// <summary>
        /// Calcule le bénefice du tour grace à la vente de produit
        /// </summary>
        /// <param name="p">Produit à vendre</param>
        /// <param name="b">Boost actif pour la vente</param>
        /// <returns></returns>
        public Product BenefitCalcul(Product p, Boost b)
        {
            double demande = p.Elasticité * (p.LastPrice - p.ResalePrice);
            double vente =  p.Quantity - (p.Quantity * demande);

                if(b.Etat == false)
                {
                    vente = vente + vente * b.Bonus;  
                }

           if(vente > p.Quantity)
              {
                    vente = p.Quantity;
              }

            if (vente < 0)
            {
                vente = 0;
            }

            ownWin += vente * p.ResalePrice;
            p.Quantity = p.Quantity - (int)vente;
            return p;
        }
    }
}
