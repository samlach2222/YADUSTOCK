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
        private List<Product> buyList;
        private int nbTour;
        private List<Boost> buyBoostList;

        private Market market = new Market();
        private Stock stock;
        private Account account;
        private SaleMarket salemarket = new SaleMarket();
        public Market Market { get => market; }
        public Account Account { get => account; }
        public Stock Stock { get => stock; }

        public Memory()
        {
            this.nbTour = 1;
            Initialize();
        }

        public void Purchase(TypeProduct p, int quantity)
        {
           for(int i = 0; i <= buyList.Count(); i++)
            {
                if(p == buyList[i].Name)
                {
                    buyList[i] = market.Purchase(buyList[i], quantity);
                    salemarket.OwnWin = salemarket.OwnWin - buyList[i].AtBuyPrice * quantity;
                }
            }

           
        }

        public void PurchaceBoost(TypeBoost b)
        {
            for (int i = 0; i <= buyBoostList.Count(); i++)
            {
                if (b == buyBoostList[i].Name)
                {
                    buyBoostList[i] = market.PurchaseBoost(buyBoostList[i]);
                }
            }
        }

        public void NextTurn()
        {          
            for(int i = 0; i <= buyList.Count; i++)
            {
                foreach (Boost r in buyBoostList)
                {
                    if (r.Name == TypeBoost.PUB)
                    {
                        salemarket.BenefitCalcul(buyList[i], r);
                    }

                }
                buyList[i] = market.IsDelivery(buyList[i]);
            }

            stock.ModifyStock(buyList);
            foreach (Boost r in buyBoostList)
            {
                if(r.TimeEnd == 0)
                {
                    r.Etat = false;
                }
                else
                {
                    r.TimeEnd = r.TimeEnd - 1;
                }
            }

            account.Own += salemarket.OwnWin;
            nbTour += 1;
        }

        public void Initialize()
        {
            buyList = CreateListProduct();
            buyBoostList = CreateListBoost();
            stock = new Stock(buyList);
            account = new Account(1921, buyBoostList);
        }

        public void ResetList()
        {
            this.buyList = null;
        }

        public List<Boost> CreateListBoost()
        {
            List<Boost> p = new List<Boost>();
            p.Add(new Boost(TypeBoost.NEGOCIATION, 0.1, 10000));
            p.Add(new Boost(TypeBoost.PUB, 0.1, 20000));
            return p;
        }

        public List<Product> CreateListProduct()
        {
            List<Product> p = new List<Product>();
            p.Add(new Product(TypeProduct.TAROT, 10, 1000));
            p.Add(new Product(TypeProduct.CARTE, 10, 2000));
            p.Add(new Product(TypeProduct.MAGIC, 10, 500));
            p.Add(new Product(TypeProduct.POKEMON, 10, 100));
            p.Add(new Product(TypeProduct.YUGIOH, 10, 50));
            return p;
        }
    }
}
