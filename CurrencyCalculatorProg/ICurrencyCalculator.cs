using System.Collections.Generic;

namespace Shenkar.CurrencyCalculatorProg
{
    /// <summary>
    /// the calculator interface
    /// </summary>
    /// <typeparam name="TK">key</typeparam>
    /// <typeparam name="TV">value</typeparam>
    public interface ICurrencyCalculator<TK, TV>
    {
        /// <summary>
        /// calculates and return the convertion's result
        /// </summary>
        /// <param name="fromCurrencyObject">fromCurrencyObjec from which coin to convert</param>
        /// <param name="toCurrencyObject">toCurrencyObject into which coin to convert</param>
        /// <param name="amount"></param>
        /// <returns>conversion result</returns>
        double CalulateConvert(CurrencyObject fromCurrencyObject, CurrencyObject toCurrencyObject, double amount);

        /// <summary>
        /// Create a Dictionary of CurrencyObects with string keys
        /// </summary>
        IDictionary<TK, TV> CurrencyDictionary { get; }

        /// <summary>
        /// Indexer
        /// </summary>
        /// <param name="key">string</param>
        /// <returns>CuurencyObjact</returns>
        TV this[TK key] { get; set; }    
    }  
}
