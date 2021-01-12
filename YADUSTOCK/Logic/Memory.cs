using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Media;

namespace Logic
{
    [DataContract]
    public class Memory : CreateBoost, CreateProduct
    {
        [DataMember] private List<Product> buyList;
        [DataMember] private int nbTour;
        [DataMember] private List<Boost> buyBoostList;
        [DataMember] private System.Media.SoundPlayer player;
        [DataMember] private Market market = new Market();
        [DataMember] private Stock stock;
        [DataMember] private Account account;
        [DataMember] private SaleMarket salemarket = new SaleMarket();

        // DEBUT SAUVEGARDE SONS ET STATUS
        [DataMember] private Uri uri;
        [DataMember] private Uri uriHover;
        [DataMember] private bool bgSoundNotRunning; //Default value : False
        [DataMember] private Uri uriSave;
        [DataMember] private Uri uriHoverSave;
        // FIN SAUVEGARDE SONS ET STATUS


        public Market Market { get => market; }
        public Account Account { get => account; }
        public Stock Stock { get => stock; }
        public int NbTour { get => nbTour;}
        public List<Product> BuyList { get => buyList; }
        public List<Boost> BuyBoostList { get => buyBoostList; }
        public Uri Uri { get => uri; set => uri = value; }
        public SoundPlayer Player { get => player; set => player = value; }
        public Uri UriHover { get => uriHover; set => uriHover = value; }
        public bool BgSoundNotRunning { get => bgSoundNotRunning; set => bgSoundNotRunning = value; }
        public Uri UriSave { get => uriSave; set => uriSave = value; }
        public Uri UriHoverSave { get => uriHoverSave; set => uriHoverSave = value; }

        public Memory()
        {
            this.uriHover = new Uri(@"../../Ressources/Sounds/hover.wav", UriKind.Relative);
            this.nbTour = 1;
            this.buyList = this.CleanListProduct();
            this.buyBoostList = this.CreateListBoost();
            this.account = new Account(5000, this.CreateListBoost());
            this.stock = new Stock(this.CreateListProduct());
        }

        public void PurchaceBoost(TypeBoost b)
        {
            for (int i = 0; i < buyBoostList.Count(); i++)
            {
                if (b == buyBoostList[i].Name)
                {
                    buyBoostList[i] = market.PurchaseBoost(buyBoostList[i]);
                    salemarket.OwnWin -= buyBoostList[i].Price;
                }
            }
        }

        public void NextTurn()
        {          
            for(int i = 0; i < stock.StockPlay.Count; i++)
            {
                foreach(Boost b in account.BoostList)
                {
                    if(b.Name == TypeBoost.PUB)
                    {
                        stock.StockPlay[i] = this.salemarket.BenefitCalcul(stock.StockPlay[i], b);
                    }
                }
                
            }

            for (int i = 0; i < buyList.Count; i++)
            {
                
              if(buyList[i].QuantityToBuy != 0)
              {
                    buyList[i] = market.Purchase(buyList[i]);
                    

                    bool test = true;
                    int j = 0;
                    while (test)
                    {
                        if ((account.BoostList[j].Name == TypeBoost.NEGOCIATION)&& (account.BoostList[j].Etat))
                        {                     
                            account.Own += buyList[i].QuantityToBuy * (buyList[i].AtBuyPrice - buyList[i].AtBuyPrice* account.BoostList[j].Bonus);
                            test = false;
                        }
                        else
                        {
                            account.Own -= buyList[i].QuantityToBuy * buyList[i].AtBuyPrice;
                            test = false;
                        }
                    }
                    
               }
            }

            foreach(Boost b in Account.BoostList)
            {
                if(b.TimeEnd == 0)
                {
                    b.Etat = false;
                }
                else
                {
                    b.TimeEnd -= 1;
                }
            }

            for (int i = 0; i < buyBoostList.Count(); i++)
            {
                account.BoostList[i] = buyBoostList[i];
            }

            nbTour += 1;

            // fin transaction
            account.Own += salemarket.OwnWin;

            //impot
            account.Own -= account.Own * 0.05;

            //Frais des locaux
            account.Own -= 7500;

            //frais des stocks
            foreach(Product p in stock.StockPlay)
            {
                account.Own -= 2 * p.Quantity;
            }

            stock.ModifyStock(buyList);
            salemarket.OwnWin = 0;
            buyList = CleanListProduct();
            buyBoostList = CreateListBoost();
        }

        public List<Boost> CreateListBoost()
        {
            List<Boost> p = new List<Boost>();
            p.Add(new Boost(TypeBoost.NEGOCIATION, 0.2, 10000, 2));
            p.Add(new Boost(TypeBoost.PUB, 0.3, 20000, 3));
            return p;
        }

        public List<Product> CreateListProduct()
        {
            List<Product> p = new List<Product>();
            p.Add(new Product(TypeProduct.TAROT, 10, 1000, -0.02));
            p.Add(new Product(TypeProduct.CARTE, 20, 2000, -0.03));
            p.Add(new Product(TypeProduct.MAGIC, 25, 500, -0.04));
            p.Add(new Product(TypeProduct.POKEMON, 15, 100, -0.05));
            p.Add(new Product(TypeProduct.YUGIOH, 30, 50, -0.02));
            return p;
        }



        public List<Product> CleanListProduct()
        {
            List<Product> p = new List<Product>();
            p.Add(new Product(TypeProduct.TAROT, 10, 0, -0.02));
            p.Add(new Product(TypeProduct.CARTE, 20, 0, -0.03));
            p.Add(new Product(TypeProduct.MAGIC, 25, 0, -0.04));
            p.Add(new Product(TypeProduct.POKEMON, 15, 0, -0.05));
            p.Add(new Product(TypeProduct.YUGIOH, 30, 0, -0.02));
            return p;
        }
    }
}
