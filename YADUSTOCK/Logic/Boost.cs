using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Boost : CreateHashBoost
    {
        private readonly TypeBoost name;
        private readonly double bonus;
        private int timeEnd;
        private readonly Boolean etat;

        public Boost(TypeBoost n, double b)
        {
            this.etat = false;
            // A CODER
        }

        public TypeBoost Name => name;
        public double Bonus => bonus;
        public int TimeEnd { get => timeEnd; set => timeEnd = value; }
        public bool Etat => etat;

        public Boost[] CreateListBoost()
        {
            // A CODER
            throw new NotImplementedException();
        }
    }
}
