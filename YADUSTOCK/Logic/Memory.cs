using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Memory : CreateHashBoost, CreateProduct
    {
        private Product[] buyList;
        private int Own = 10000;
        private Boost[] buyBoostList;

        private readonly Market market;
        private readonly Stock stock;
        private readonly Account account;

        public Memory() 
        {
            // A CODER
        }

        public void BenefitCalcul() 
        {
            // A CODER
        }

        public void Purchase(TypeProduct p, int quantity)
        {
            // A CODER
        }

        public void PurchaceBoost(TypeBoost b)
        {
            // A CODER
        }

        public void NextTurn()
        {
            // A CODER
        }

        public void Initialize()
        {
            // A CODER
        }

        public void ResetList()
        {
            // A CODER
        }

        public Boost[] CreateListBoost()
        {
            // A CODER
            throw new NotImplementedException();
        }

        public Product[] CreateListProduct()
        {
            // A CODER
            throw new NotImplementedException();
        }
    }
}
