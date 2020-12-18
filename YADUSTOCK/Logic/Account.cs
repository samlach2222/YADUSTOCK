using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Account
    {
        private double own;
        private List<Boost> boostList;

        public Account(double o, List<Boost> b)
        {
            own = o;
            boostList = b;
        }

        public double Own { get => own; set => own = value; }
        public List<Boost> BoostList { get => boostList; set => boostList = value; }
    }
}
