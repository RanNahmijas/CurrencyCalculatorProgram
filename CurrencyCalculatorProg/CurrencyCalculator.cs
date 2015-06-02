using System;
using System.Collections.Generic;
using System.Globalization;

namespace Shenkar.CurrencyCalculatorProg
{
    /// <summary>
    /// This class implement the interface ICurrencyCalculator
    /// </summary>
    public class CurrencyCalculator : ICurrencyCalculator<string, CurrencyObject>
    {
        #region Variables

        //currencies Data Collection
        private IDictionary<string, CurrencyObject> currenciesDataDictionary;
        //instance for Singleton implementation
        private static volatile CurrencyCalculator calcInstance; 
        //object to lock, instead of locking the instance itself, lock this object to avoid deadlocks
        private static readonly Object SyncRoot = new Object();
       

        #endregion

        #region C'tor

         /// <summary>
        /// C'tor - private C'tor for Singleton implementation
        /// </summary>
        private CurrencyCalculator()
        {
            currenciesDataDictionary = new Dictionary<string, CurrencyObject>()
            {
                {
                    //create new currency - Israeli shekel and add it to the dictionary
                    "ILS", new CurrencyObject
                    {
                        Name = "Shekel",
                        Unit = 1,
                        CurrencyCode = "ILS",
                        Country = "Israel",
                        Rate = 1,
                        Change = 0,
                        IconPath = "Images\\ILS.png"
                    }
                }
            };
        }
     
        #endregion

        #region Singleton 

        /// <summary>
        /// Singleton implementation
        /// </summary>
        public static CurrencyCalculator Instance
        {
            get
            {
                //The following implementation allows only a single thread to enter the critical area, 
                //which the lock block identifies, when no instance of Singleton has yet been created
                if (calcInstance == null)
                {
                    //this approach uses a syncRoot instance to lock on,
                    //rather than locking on the type itself, to avoid deadlocks
                    lock (SyncRoot)
                    {
                        if (calcInstance == null)
                        {
                            calcInstance = new CurrencyCalculator();
                        }
                    }
                }
                return calcInstance;
            }
        }

        #endregion

        /// <summary>
        /// calculates and return the convertion's result
        /// </summary>
        /// <param name="fromCurrencyObject">fromCurrencyObjec from which coin to convert</param>
        /// <param name="toCurrencyObject">toCurrencyObject into which coin to convert</param>
        /// <param name="amount"></param>
        /// <returns>conversion result</returns>
        public double CalulateConvert(CurrencyObject fromCurrencyObject, CurrencyObject toCurrencyObject, double amount)
        {
            var calcResult = amount / toCurrencyObject * fromCurrencyObject;
            calcResult = Math.Round(calcResult, 4);
            return calcResult;
        }

        /// <summary>
        /// get Enumerator function
        /// </summary>
        /// <returns>CurrencyObject</returns>
        public IEnumerator<CurrencyObject> GeteEnumerator()
        {
            foreach (string currencyKey in currenciesDataDictionary.Keys)
            {
                yield return currenciesDataDictionary[currencyKey];
            }
        }

        /// <summary>
        /// property for CurrencyDictionary (currencies collection)
        /// </summary>
        public IDictionary<string, CurrencyObject> CurrencyDictionary
        {
            get { return currenciesDataDictionary; }
        }

        /// <summary>
        /// Indexer Property
        /// </summary>
        /// <param name="key">string</param>
        /// <returns>CurrencyObject</returns>
        public CurrencyObject this[string key]
        {
            get { return currenciesDataDictionary[key]; }
            set { currenciesDataDictionary[key] = value; }
        }

        /// <summary>
        /// Property - set and get the date from Bank of Israel XML file
        /// </summary>
        public static DateTime CurrenciesXMLDate { get; set; }
    }
}
