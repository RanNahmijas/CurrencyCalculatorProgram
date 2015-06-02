using System;

namespace Shenkar.CurrencyCalculatorProg
{
    public class CurrencyObject
    {
        #region Private Variables

        // CurrencyObject name
	    private string name;
	    // CurrencyObject Unit - represent how many unit of this currency the rate stand for 
	    private int unit;
	    // CurrencyObject Code - the standard Code of the currency (e.g. USD) 
	    private string currencyCode;
	    // Country - the country that use the currency 
	    private string country;
	    // CurrencyObject Rate - the rate of the currency relative to NIS  
	    private double rate;
	    // CurrencyObject Change - represent the change in the currency rate
	    private double change;
	    //CurrencyObject Icon - represent the Icon of the country that use the currency
	    private string iconPath;

        #endregion

        #region Properties

        /// <summary>
        /// Property for the name variable
        /// </summary>
        public string Name
        {
            get { return name; }
            set
            {
                if (!String.IsNullOrEmpty(value) && !value.Equals(name))
                {
                    name = value;
                }
            }
        }

        /// <summary>
        /// Property for the unit variable
        /// </summary>
        public int Unit
        {
            get { return unit; }
            set
            {
                if (value > 0 && value != unit)
                {
                    unit = value;
                }
            }
        }

        /// <summary>
        /// Property for the currencyCode variable
        /// </summary>
        public string CurrencyCode
        {
            get { return currencyCode; }
            set
            {
                if (!String.IsNullOrEmpty(value) && !value.Equals(currencyCode))
                {
                    currencyCode = value;
                }
            }
        }

        /// <summary>
        /// Property for the country variable
        /// </summary>
        public string Country
        {
            get { return country; }
            set
            {
                if (!String.IsNullOrEmpty(value) && !value.Equals(country))
                {
                    country = value;
                }
            }
        }

        /// <summary>
        /// Property for the change variable
        /// </summary>
        public double Change
        {
            get { return change; }
            set 
            {
                if (value > 0 && value != change)
                {
                    change = value;
                }
            }
        }

        /// <summary>
        /// Property for the rate variable
        /// </summary>
        public double Rate
        {
            get { return rate; }
            set
            {
                if (value > 0 && value != rate)
                {
                    rate = value;
                }
            }
        }

        /// <summary>
        /// Property for the iconPath variable
        /// </summary>
        public string IconPath
        {
            get { return iconPath; }
            set
            {
                if (!String.IsNullOrEmpty(value) && !value.Equals(iconPath))
                {
                    iconPath = value;
                }
            }
        }

        #endregion
        
        /// <summary>
        /// implicit double operator to get the rate exchange by object
        /// </summary>
        public static implicit operator double(CurrencyObject objectToCalc)
        {
            return objectToCalc.Rate / objectToCalc.Unit;
        }
       
    }
}
