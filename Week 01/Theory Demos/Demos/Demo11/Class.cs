using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo11
{
    #region Όλα τα αντικείμενα υλοποιούν ένα Interface
    public interface ICurrencyObserver
    {
        void SetPriceInDollars(decimal rate);
    }

    public class Item : ICurrencyObserver
    {
        public Decimal PriceInEuro { get; set; }
        public Decimal PriceInDollars { get; private set; }

        public void SetPriceInDollars(decimal rate)
        {
            PriceInDollars = PriceInEuro / rate;
        }
    }
    public class Product : ICurrencyObserver
    {
        public Decimal PriceInEuro { get; set; }
        public Decimal PriceInDollars { get; private set; }

        public void SetPriceInDollars(decimal rate)
        {
            PriceInDollars = PriceInEuro / rate;
        }
    }
    #endregion

    #region Όλα τα αντικείμενα κληρονομούν από μία Abstract κλάση
    public abstract class CurrencyConverterAbstract
    {
        public Decimal PriceInDollars { get; protected set; }
        public abstract void SetPriceInDollars(decimal rate);
    }

    public class ItemAbstract : CurrencyConverterAbstract
    {
        public Decimal PriceInEuro { get; set; }

        public override void SetPriceInDollars(decimal rate)
        {
            PriceInDollars = PriceInEuro / rate;
        }
    }

    public class ProductAbstract : CurrencyConverterAbstract
    {
        public Decimal PriceInEuro { get; set; }

        public override void SetPriceInDollars(decimal rate)
        {
            PriceInDollars = PriceInEuro / rate;
        }
    }
    #endregion

    public class CurrencyInformer
    {
        // Χρησιμοποιείτε μία από τις παρακάτω προσσεγγίσεις

        // Με λίστα από μεθόδους
        public List<Action<decimal>> ObserverAddedMethods;

        // Με λίστα από Interfaces
        public List<ICurrencyObserver> ObserverAddedInterfaces { get; set; }

        // Με λίστα από Abstract classes
        public List<CurrencyConverterAbstract> ObserverAddedAbstractClasses { get; set; }

        //Με λίστα από γενικά αντικείμενα (Όχι τόσο καλή προσσέγγιση)
        public List<object> ObserverAddedObjects;
        

        public CurrencyInformer()
        {
            ObserverAddedMethods = new List<Action<decimal>>();
            ObserverAddedInterfaces = new List<ICurrencyObserver>();
            ObserverAddedAbstractClasses = new List<CurrencyConverterAbstract>();
            ObserverAddedObjects = new List<object>();
        }
        public void ChangeUSDCurrencyRate(Decimal Rate)
        {
            for (int i = 0; i < ObserverAddedMethods.Count; i++)
                ObserverAddedMethods[i](Rate);

            for (int i = 0; i < ObserverAddedInterfaces.Count; i++)
                ObserverAddedInterfaces[i].SetPriceInDollars(Rate);

            for (int i = 0; i < ObserverAddedAbstractClasses.Count; i++)
                ObserverAddedAbstractClasses[i].SetPriceInDollars(Rate);

            for (int i = 0; i < ObserverAddedObjects.Count; i++)
            {
                if (ObserverAddedObjects[i].GetType() == typeof(Item))
                    ((Item)ObserverAddedObjects[i]).SetPriceInDollars(Rate);

                if (ObserverAddedObjects[i].GetType() == typeof(Product))
                    ((Product)ObserverAddedObjects[i]).SetPriceInDollars(Rate);
            }

        }


    }
}
