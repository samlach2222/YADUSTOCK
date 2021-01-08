using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Boost
    {
        private readonly TypeBoost name;
        private readonly double bonus;
        private int timeEnd;
        private Boolean etat;
        private readonly double price;


        public Boost(TypeBoost n, double b, double p)
        {
            this.etat = false;
            this.name = n;
            this.bonus = b;
            this.price = p;
        }

        public TypeBoost Name => name;
        public double Bonus => bonus;
        public int TimeEnd { get => timeEnd; set => timeEnd = value; }
        public bool Etat { get => etat; set => etat = value; }
        public double Price => price;
    }
}
