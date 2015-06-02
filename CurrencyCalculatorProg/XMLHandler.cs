using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Xml;
using System.Xml.Linq;


namespace Shenkar.CurrencyCalculatorProg
{
    /// <summary>
    /// XMLHandler - get the xml from Bank of Israel and parse it
    /// </summary>
    [System.ComponentModel.DesignerCategory("Code")]
    public class XMLHandler : WebClient
    {
        #region Variables
        // event- invoke event to main window - event of notifing user with MessageBox
        internal static event UserMessageDelegate UserMessage;
        //Bank of Israel URL
        public static string XMLUrlString;
        //Connection TimeOut
        public static int WebRequestTimeout;
        //where to save the XML file
        public static string XMLFile = "currensyData.xml";
        #endregion

        #region C'tors
        /// <summary>
        /// constructor- set the url and the Timeou
        /// </summary>
        static XMLHandler()
        {
            XMLUrlString = @"http://www.bankisrael.gov.il/currency.xml";
            WebRequestTimeout = 4000;
        }
        #endregion

        /// <summary>
        /// Method, this manager will invoke the currencies collection buildup
        /// only if there is a newer XML to get, or in the first launch of this program
        /// if there is no newer XML to get, it will finish the exceute of the Async Task
        /// </summary>
        public bool CheckIfXMLChanged()
        {
            //represents an XML element 
            XElement currencyXML;
            //holds string that represents XML content
            string xmlContent;
            bool isXMLEqual = false;

            //fetch and parse XML
            LoadAndParseXML(out currencyXML, out xmlContent);

            try
            {
                //check if the XML is without any problems
                if (currencyXML != null && currencyXML.Elements().Count() > 10)
                {
                    //save the XML into a file for future use
                    File.WriteAllText(new DirectoryInfo(Path.Combine(Environment.CurrentDirectory, XMLFile)).ToString(),
                        xmlContent);
                }

                //there is a problem with the XML doc
                else
                {
                    //XML element is loaded from the saved file
                    currencyXML = XElement.Parse(File.ReadAllText(Path.Combine(Environment.CurrentDirectory, XMLFile)));
                }

                //Chacking the 'LAST_UPDATE' element from XML file
                //to avoid getting the same XML with no change
                var xElement = currencyXML.Element("LAST_UPDATE");
                if (ChackLastUpdate(xElement.Value))
                {
                    isXMLEqual = true;
                }
                //else, there is newer XML, or this is the first launch of the program, invoke the GetCurrancyElements
                //and get new elements
                else
                {
                    GetCurrancyElements(currencyXML);
                }
            }
            //no backup file found
            catch (FileNotFoundException)
            {
                if (UserMessage != null)
                    UserMessage.Invoke(
                        @"ERROR!" + "\r\n" + "No backup file found" + "\r\n" +
                        "Please check your Internet connection...");
                //exit program
                Environment.Exit(0);
            }
            return isXMLEqual;
        }

        /// <summary>
        /// This method get the currancy XML from Bank of Israel and parse it
        /// </summary>
        public void LoadAndParseXML(out XElement currencyXML, out string xmlContent)
        {
            try
            {
                //downloading XML as a string
                xmlContent = DownloadString(new Uri(XMLUrlString));
                //parse the document
                currencyXML = XElement.Parse(xmlContent);
            }

            //in a case of a web connection problem
            catch (WebException)
            {
                currencyXML = null;
                xmlContent = null;
                UserMessage(@"Please note that there is network problem, "
                            + "\r\n" + "Currency data loaded from the latest file.");

            }
            //in a case that there is a problem with the XML
            catch (XmlException)
            {
                currencyXML = null;
                xmlContent = null;
                UserMessage(@"Please note that due to Bank of Israel XML file problems, "
                            + "\r\n" + "Currency data loaded from the latest file.");
            }

        }

        /// <summary>
        /// This method get the XML elements by LINQ,
        /// and fill the CurrencyDictionary
        /// </summary>
        public void GetCurrancyElements(XElement currenciesElements)
        {
            try
            {
                //LINQ TO XML
                (from currencyElement in currenciesElements.Descendants("CURRENCY")
                 select new CurrencyObject
                 {
                     Name = (string)currencyElement.Element("NAME"),
                     Unit = (int)currencyElement.Element("UNIT"),
                     CurrencyCode = (string)currencyElement.Element("CURRENCYCODE"),
                     Country = (string)currencyElement.Element("COUNTRY"),
                     Rate = (double)currencyElement.Element("RATE"),
                     Change = (double)currencyElement.Element("CHANGE"),
                     IconPath = "Images\\" + (string)currencyElement.Element("CURRENCYCODE") + ".png"
                 })
                    //ToList()- to list, enumrable, so iterator can be used
                    //ForEach() -iterates the list, and add nodes to container
                    //Key - Currency Code - e.g: 'USD'
                    //value- Currency node - object        
                    .ToList()
                    .ForEach(currencyNode => CurrencyCalculator.Instance[currencyNode.CurrencyCode] = currencyNode);
            }

            catch (NullReferenceException)
            {
                UserMessage("Please note that due to Bank of Israel XML file problems, "
                            + "\r\n" + "Currency data loaded from the latest file.");
            }
            catch (FormatException)
            {
                UserMessage("Please note that due to Bank of Israel XML file problems, "
                            + "\r\n" + "Currency data loaded from the latest file.");
            }             
        }

        /// <summary>
        /// override method to overcome problematic network, and set a timeout for the XML fetch
        /// so the program will not get stuck on the fetch process
        /// </summary>
        protected override WebRequest GetWebRequest(Uri address)
        {
            //set web request for the server
            var webRequestResult = base.GetWebRequest(address);
            //set the timout for this operation
            webRequestResult.Timeout = WebRequestTimeout;
            //return result from server
            return webRequestResult;
        }

        /// <summary>
        /// Compares the current XML date and the one that is save on the file
        /// for avoid fatching and parsing the XML if they are the same
        /// </summary>
        /// <param name="lastXMLUpdate">date value of the fatched XML</param>
        /// <returns>true - the dates are equal, else false</returns>
        public bool ChackLastUpdate(string lastXMLUpdate)
        {
            DateTime date = Convert.ToDateTime(lastXMLUpdate);
            if (!CurrencyCalculator.CurrenciesXMLDate.Equals(date))
            {
                CurrencyCalculator.CurrenciesXMLDate = date;
                return false;
            }
            return true;
        }
    }
}
