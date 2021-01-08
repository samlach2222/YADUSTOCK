using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class SaleMarket
    {
        private double ownWin = 0;

        public double OwnWin { get => ownWin; set=> ownWin = value; }

        public Product BenefitCalcul(Product p, Boost b)
        {
            double demande = p.Elasticité * (p.LastPrice - p.ResalePrice);
            double vente =  p.Quantity * demande;

                if(b.Etat == true)
                {
                vente = vente * (float)b.Bonus;  
                }
            ownWin += vente * p.ResalePrice;
            p.Quantity = p.Quantity - (float)vente;
            return p;
        }
    }
}
