using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Logic
{
    [DataContract]
    public class Boost
    {
        [DataMember] private readonly TypeBoost name;
        [DataMember] private readonly double bonus;
        [DataMember] private int timeEnd;
        [DataMember] private Boolean etat;
        [DataMember] private readonly double price;

        /// <summary>
        /// permet de crée un boost
        /// </summary>
        /// <param name="n">Type du boost</param>
        /// <param name="b">Bonus apporter par le boost</param>
        /// <param name="p">Prix du boost</param>
        /// <param name="t">Temps d'activation du boost</param>
        public Boost(TypeBoost n, double b, double p, int t)
        {
            this.etat = false;
            this.name = n;
            this.bonus = b;
            this.price = p;
            this.timeEnd = t;
        }

        public TypeBoost Name => name;
        public double Bonus => bonus;
        public int TimeEnd { get => timeEnd; set => timeEnd = value; }
        public bool Etat { get => etat; set => etat = value; }
        public double Price => price;
    }
}
