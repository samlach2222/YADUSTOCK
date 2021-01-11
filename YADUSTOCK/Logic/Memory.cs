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
            Initialize();
            this.buyList = this.CreateListProduct();
            this.buyBoostList = this.CreateListBoost();
            this.account = new Account(5000, this.CreateListBoost());
            this.stock = new Stock(this.buyList);
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
            for(int i = 0; i < buyList.Count; i++)
            {
                foreach (Boost r in account.BoostList)
                {
                    if (r.Name == TypeBoost.PUB)
                    {
                        buyList[i] = salemarket.BenefitCalcul(buyList[i], r);
                    }

                }
                buyList[i] = market.IsDelivery(buyList[i]);
            }

            stock.ModifyStock(buyList);
            foreach (Boost r in account.BoostList)
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
            account.BoostList = buyBoostList;
            buyBoostList = this.CreateListBoost();
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

        public List<Boost> CreateListBoost()
        {
            List<Boost> p = new List<Boost>();
            p.Add(new Boost(TypeBoost.NEGOCIATION, 0.1, 10000, 2));
            p.Add(new Boost(TypeBoost.PUB, 0.1, 20000, 3));
            return p;
        }

        public List<Product> CreateListProduct()
        {
            List<Product> p = new List<Product>();
            p.Add(new Product(TypeProduct.TAROT, 10, 1000, -0.2));
            p.Add(new Product(TypeProduct.CARTE, 10, 2000, -0.4));
            p.Add(new Product(TypeProduct.MAGIC, 10, 500, -0.1));
            p.Add(new Product(TypeProduct.POKEMON, 10, 100, -0.5));
            p.Add(new Product(TypeProduct.YUGIOH, 10, 50, -0.3));
            return p;
        }
    }
}
