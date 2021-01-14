using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    [DataContract]
    public class Account
    {
        [DataMember] private double own;
        [DataMember] private List<Boost> boostList;

        /// <summary>
        /// Constructeur de la classe
        /// </summary>
        /// <param name="o">Fond monètaire au début du jeu</param>
        /// <param name="b">Liste des boost à l'initialisation</param>
        public Account(double o, List<Boost> b)
        {
            own = o;
            boostList = b;
        }

        public double Own { get => own; set => own = value; }
        public List<Boost> BoostList { get => boostList; set => boostList = value; }
    }
}
