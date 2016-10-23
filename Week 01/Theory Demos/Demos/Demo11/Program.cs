using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo11
{
    // Observer pattern με διάφορους τρόπους
    class Program
    {
        static void Main(string[] args)
        {
            CurrencyInformer CI = new CurrencyInformer();

            Product p1 = new Product() { PriceInEuro = 10 };
            Product p2 = new Product() { PriceInEuro = 15 };
            Item i1 = new Item() { PriceInEuro = 22 };

            ProductAbstract p1a = new ProductAbstract() { PriceInEuro = 10 };
            ProductAbstract p2a = new ProductAbstract() { PriceInEuro = 15 };
            ItemAbstract i1a = new ItemAbstract() { PriceInEuro = 22 };

            CI.ObserverAddedAbstractClasses.Add(p1a);
            CI.ObserverAddedAbstractClasses.Add(p2a);
            CI.ObserverAddedAbstractClasses.Add(i1a);

            CI.ObserverAddedInterfaces.Add(p1);
            CI.ObserverAddedInterfaces.Add(p2);
            CI.ObserverAddedInterfaces.Add(i1);

            CI.ObserverAddedObjects.Add(p1);
            CI.ObserverAddedObjects.Add(p2);
            CI.ObserverAddedObjects.Add(i1);

            CI.ObserverAddedMethods.Add(p1.SetPriceInDollars);
            CI.ObserverAddedMethods.Add(p2.SetPriceInDollars);
            CI.ObserverAddedMethods.Add(i1.SetPriceInDollars);
            CI.ObserverAddedMethods.Add(p1a.SetPriceInDollars);
            CI.ObserverAddedMethods.Add(p2a.SetPriceInDollars);
            CI.ObserverAddedMethods.Add(i1a.SetPriceInDollars);

            CI.ChangeUSDCurrencyRate(0.8M);
        }
    }
}
