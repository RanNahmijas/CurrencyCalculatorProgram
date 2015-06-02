using System;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Windows;
using System.Windows.Controls.Primitives;

namespace Shenkar.CurrencyCalculatorProg
{
    #region Delegates
    /// <summary>
    /// a generic delegate type which handle the asyncronious task of getting XML
    /// <returns>bool</returns>
    /// </summary>
    internal delegate T FetchAndParseDataAsynchronousDelegate<out T>();
    /// <summary>
    /// a delegate type with an event is attached to it.
    /// Used for sending messages to the user  
    /// </summary>
    internal delegate void UserMessageDelegate(string message);

    #endregion

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //the calculator instance
        private readonly ICurrencyCalculator<string, CurrencyObject> calculator;

        /// <summary>
        /// Main Window C'tor
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            Title = "Loading...";
            calculator = CurrencyCalculator.Instance;
            XMLHandler.UserMessage += NotifyUserPopBox;            
            GetXMLAsynchronously();
        }

        /// <summary>
        /// get the Xml Asynchronously 
        /// </summary>
        private void GetXMLAsynchronously()
        {
            using (var fatchAndParseXML = new XMLHandler())
            {
                //attach the XMLHandler to the async delegate type
                FetchAndParseDataAsynchronousDelegate<bool> asyncFetchAndParse = fatchAndParseXML.CheckIfXMLChanged;
                //begin the async work, and register a callback func
                asyncFetchAndParse.BeginInvoke(AsynchronousTaskCallback, null);
            }
        }

        /// <summary>
        /// the GetXMLAsynchronously Callback - fills the combo boxes and the currencies table
        /// </summary>
        /// <param name="ar">represents the status of async operation</param>
        public void AsynchronousTaskCallback(IAsyncResult ar)
        {
            //get the result of the XMLHandler
            AsyncResult result = (AsyncResult)ar;
            //get boolean var
            var bankXMLDalegate = (FetchAndParseDataAsynchronousDelegate<bool>)result.AsyncDelegate;

            //check for the returning callback
            //if true, the XML's dates are equal and there is no need to get
            //new one, and initilize the GUI component, such the datagrid  and the Comboboxes
            if (!bankXMLDalegate.EndInvoke(ar))
            {
                //raising UI event in the middle of background thread - by Annonmyous method 
                Dispatcher.Invoke(new Action(() =>
                {
                     //sets the content of the table and comboBoxes
                    SetItemsSource();

                    //set the title with date of XML
                    Title = "Currency Calculator - Last XML Update: " + CurrencyCalculator.CurrenciesXMLDate.ToShortDateString();

                    //set GUI componnet as enable           
                    AmountTextBox.IsEnabled = true;

                }));
            }
        }
        
        /// <summary>
        /// sets the content of the table and comboBoxes
        /// </summary>
        private void SetItemsSource()
        {
            //attach the Currenecy Codes to the Combo boxes lists
            FromComboBox.ItemsSource = (from currencyItem in CurrencyCalculator.Instance.CurrencyDictionary.Values
                                        orderby currencyItem.Country ascending
                                        select currencyItem.Country + "-" + currencyItem.CurrencyCode);
            //attach to the other side of the currency combobox also
            ToComboBox.ItemsSource = FromComboBox.ItemsSource;

            //set the ratedatagrid view of coins
            //except deafult value - israel
            CurrenciesDataGrid.ItemsSource = (from currencyItem in CurrencyCalculator.Instance.CurrencyDictionary.Values
                                              where currencyItem.Country != "Israel"
                                              orderby currencyItem.Country ascending
                                              select currencyItem);
        }

        #region Command buttons

        /// <summary>
        /// Button command for - show\hide currencies table 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.CurrenciesDataGrid.Visibility == System.Windows.Visibility.Collapsed)
            {
                this.CurrenciesDataGrid.Visibility = System.Windows.Visibility.Visible;
                this.ShowButton.Content = "Hide Currencies";
            }
            else
            {
                this.CurrenciesDataGrid.Visibility = System.Windows.Visibility.Collapsed;
                this.ShowButton.Content = "Show Currencies";
            }
            ClearValidation();
        }

        /// <summary>
        /// Button command for - switch the currencies
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SwitchButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.ToComboBox.SelectedValue != null && this.FromComboBox.SelectedValue != null)
            {
                  //set selected index of right side object
                var toComboboxIndex = ToComboBox.SelectedIndex;
                //save the selected index of leftside
                ToComboBox.SelectedIndex = FromComboBox.SelectedIndex;
                //and set the left side with the right side object
                FromComboBox.SelectedIndex = toComboboxIndex;
                //raise an event of calc operation (if the amount is fill
                if (!String.IsNullOrEmpty(this.AmountTextBox.Text))
                {
                     CalcButton.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
                }
            }
            else this.ShowValidation("Please Fill Both Combo Boxes");
            
        }

        /// <summary>
        /// Button command for - calculate the result 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CalcButton_Click(object sender, RoutedEventArgs e)
        {
            double amount;

            if (!String.IsNullOrEmpty(this.AmountTextBox.Text) && !String.IsNullOrEmpty(this.FromComboBox.Text) && !String.IsNullOrEmpty(this.ToComboBox.Text))
            {
                string fromSideComboBoxCode = FromComboBox.SelectedItem.ToString().Split('-')[1];
                string toSideComboBoxCode = ToComboBox.SelectedItem.ToString().Split('-')[1];

                if (Double.TryParse(this.AmountTextBox.Text, out amount))
                {
                    this.ResultTextBox.Text = calculator.CalulateConvert(calculator[fromSideComboBoxCode], calculator[toSideComboBoxCode], amount).ToString();
                    ClearValidation();
                }
                else
                {
                    this.ShowValidation("Please Insert a Float");
                }
            }
            else this.ShowValidation("Please Fill all the Fields");
         
        }

        /// <summary>
        /// Button command for - refresh the currencies table 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            ClearValidation();
            RefreshCurrenciesData();
        }

        /// <summary>
        /// show string validation (on the calculator)
        /// </summary>
        /// <param name="validationString"></param>
        private void ShowValidation(string validationString)
        {
            this.ValidationTextBox.Text = validationString;
        }

        /// <summary>
        /// clear the validation string
        /// </summary>
        private void ClearValidation()
        {
            this.ValidationTextBox.Text = " ";
        }

        #endregion

        /// <summary>
        /// refreshing the table and currencies data
        /// </summary>
        private void RefreshCurrenciesData()
        {
            GetXMLAsynchronously();
            this.CurrenciesDataGrid.Items.Refresh();
        }

        /// <summary>
        /// show the error massage box
        /// </summary>
        /// <param name="message"></param>
        private void NotifyUserPopBox(string message)
        {
            MessageBox.Show(message, "Notice", MessageBoxButton.OK, MessageBoxImage.Information,
               MessageBoxResult.None, MessageBoxOptions.None);
        }
     }
}
