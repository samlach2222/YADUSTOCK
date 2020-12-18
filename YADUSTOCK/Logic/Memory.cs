using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Memory : CreateBoost, CreateProduct
    {
        private Product[] buyList;
        private int nbTour;
        private Boost[] buyBoostList;
        private String namePlayer;

        private Market market;
        private Stock stock;
        private Account account;
        private SaleMarket salemarket;

        public string NamePlayer { get => namePlayer; set => namePlayer = value; }
        public Market Market { get => market;}
        public Account Account { get => account; }
        public Stock Stock { get => stock; }

        public Memory() 
        {
            this.nbTour = 1;
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

        public List<Product> CreateListProduct()
        {
            throw new NotImplementedException();
        }
    }
}
