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
        private Boost[] boostList;

        public Account(double o, Boost[] b)
        {
            // A CODER
        }

        public double Own { get => own; set => own = value; }
        public Boost[] BoostList { get => boostList; set => boostList = value; }
    }
}
