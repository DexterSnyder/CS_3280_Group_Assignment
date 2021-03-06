﻿using CS_3280_Group_Assignment.Items;
using CS_3280_Group_Assignment.Main;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CS_3280_Group_Assignment.Search
{
    /// <summary>
    /// Interaction logic for wndSearch.xaml
    /// </summary>
    public partial class wndSearch : Window
    {

        #region Lists and Arrays and Databases

        /// <summary>
        /// Create a property for the InvoiceID
        /// </summary>
        public List<clsSearchLogic> lstInvoices { get; set; }

        /// <summary>
        /// database access
        /// </summary>
        private clsSearchSQL db;

        /// <summary>
        /// list of invoice IDs
        /// </summary>
        private ArrayList invoiceIDArray;

        /// <summary>
        /// list of invoice dates
        /// </summary>
        private ArrayList invoiceDatesArray;

        /// <summary>
        /// list of invoice costs
        /// </summary>
        private ArrayList invoiceCostArray;

        #endregion

        #region Variables

        /// <summary>
        /// variable used to store the selected invoiceID from the DataGrid
        /// </summary>
        int invoiceID = 0;
        /// <summary>
        /// variable used to store the selected invoiceDate from the DataGrid
        /// </summary>
        DateTime invoiceDate = new DateTime();
        /// <summary>
        /// variable used to store the selected invoiceCharge from the DataGrid
        /// </summary>
        double invoiceCharge = 0.0;


        /// <summary>
        /// an Invoice object to help get some methods
        /// </summary>
        private Invoice inv;
        /// <summary>
        /// Get our clsSearchLogic class
        /// </summary>
        clsSearchLogic clsSearchLogicInst;

        #endregion

        #region Methods

        /// <summary>
        /// Initialize/construtor
        /// </summary>
        public wndSearch()
        {
            try
            {
                InitializeComponent();

                ///<summary>
                ///initialize our clsSearchLogicInst
                /// </summary>
                clsSearchLogicInst = new clsSearchLogic();

                ///<summary>
                ///this creates a new instance of our invoiceIDArray
                ///</summary>
                invoiceIDArray = new ArrayList();

                ///<summary>
                ///this creates a new instance of our invoiceDatesArray
                ///</summary>
                invoiceDatesArray = new ArrayList();

                ///<summary>
                ///this creates a new instance of our invoiceCostArray
                ///</summary>
                invoiceCostArray = new ArrayList();

                ///<summary>
                ///this creates a new instance of our data access to our search invoice database
                ///</summary>
                db = new clsSearchSQL();

                ///<summary>
                ///this creates a new instance of our invoice class
                /// </summary>
                inv = new Invoice();

                ///<summary>
                ///initially load our invoice dates in our combo box
                ///</summary>
                loadInvoiceDatesInComboBox();

                ///<summary>
                ///initially load our invoice dates in our combo box
                ///</summary>
                loadInvoiceIDsInComboBox();

                ///<summary>
                ///initially load our invoice costs in our combo box
                ///</summary>
                loadInvoiceCostsInComboBox();

                ///<summary>
                ///this will be used to bind to our list of invoices and display it in our search window DataGrid
                /// </summary>
                DisplaySearchedInvoice.ItemsSource = clsSearchLogicInst.GetInvoicesFromDataBase();

            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }

        }



        /// <summary>
        /// The button that the user uses to select their invoice
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectInvoiceButton_Click(object sender, RoutedEventArgs e)
        {

            //get the Main window
            // wndMain main = new wndMain();

            //call the method to display the list of the searched for invoice
            //main.DisplaySearchedForInvoices(lstInvoices);


            ///show the invoice that was searched for
            // main.ShowDialog(); 
        }

        private void ClearInvoiceButton_Click(object sender, RoutedEventArgs e)
        {
            //clear out the DataGrid
            // DisplaySearchedInvoice.Items.Clear();

            //empty the invoices list, basically reset all the properties
            //lstInvoices.Clear();

            //reset all the combo boxes
            // InvoiceDateDropDown.SelectedIndex = -1;
            // InvoiceTotalChargeDropDown.SelectedIndex = -1;
            // InvoiceNumberDropDown.SelectedIndex = -1; 
        }

        /// <summary>
        /// When a user selects a specific invoice (row) from the data grid, send the data to a function that will put it in a list and if the user selects the invoice it will send it over to the Main window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DisplaySearchedInvoice_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //exception handling
            try
            {
                DataGrid temp = (DataGrid)sender;

                //if our selected item is not null
                if (temp.SelectedItem == null)
                {
                    //convert all our values to the necessary types
                    invoiceID = Convert.ToInt32(temp.SelectedCells[0]);
                    invoiceDate = DateTime.Parse((temp.SelectedCells[1]).ToString());
                    invoiceCharge = Convert.ToDouble(temp.SelectedCells[2]);

                    //send data over to the list
                    clsSearchLogicInst.GetSearchedInvoices(invoiceID, invoiceDate, invoiceCharge);

                }
                else
                {

                    throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + "DataGrid is NULL");
                }
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                       MethodInfo.GetCurrentMethod().Name, ex.Message);
            }



        }

        #region ComboBoxes Methods

        /// <summary>
        /// when the user selects a specific invoiceID
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InvoiceNumberDropDown_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //when someone has selected a specific InvoiceID number
            //send that invoiceID to the database
            //and then our clsSearchLogic class will populate the DataGrid with the new information
            //which should just be the invoice with the specific invoiceID selected in this comboBox
        }

        /// <summary>
        /// when the user selects a specific invoiceDate
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InvoiceDateDropDown_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //when someone has selected a specific InvoiceDate dateTime
            //send that invoiceDate to the database
            //and then our clsSearchLogic class will populate the DataGrid with the new information
            //which should just be the invoice with the specific invoiceDate selected in this comboBox
        }

        /// <summary>
        /// when the user selects a specific invoiceCharge
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InvoiceTotalChargeDropDown_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //when someone has selected a specific InvoiceCharge cost
            //send that InvoiceCharge to the database
            //and then our clsSearchLogic class will populate the DataGrid with the new information
            //which should just be the invoice with the specific InvoiceCharge selected in this comboBox
        }

        #endregion


        #region Other Methods
        /// <summary>
        /// Handle the error.
        /// </summary>
        /// <param name="sClass">The class in which the error occurred in.</param>
        /// <param name="sMethod">The method in which the error occurred in.</param>
        private void HandleError(string sClass, string sMethod, string sMessage)
        {
            try
            {
                //Would write to a file or database here.
                MessageBox.Show(sClass + "." + sMethod + " -> " + sMessage);
            }
            catch (Exception ex)
            {
                System.IO.File.AppendAllText("C:\\Error.txt", Environment.NewLine +
                                             "HandleError Exception: " + ex.Message);
            }
        }


        /// <summary>
        /// Private method that will load all our invoice IDs initially when a user opens the search invoice window
        /// </summary>
        private void loadInvoiceIDsInComboBox()
        {
            try
            {
                //call our method in our clsSearchSQL file that gets all the dates in the database
                invoiceIDArray = db.getInvoiceIDs();

                //iterate through the list that the clsSearchSQL file populated
                foreach (Invoice invoice in invoiceIDArray)
                {
                    //and put them in our combobox
                    InvoiceNumberDropDown.Items.Add(invoice);

                }
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }


        /// <summary>
        /// Private method that will load all our invoice dates initially when a user opens the search invoice window
        /// </summary>
        private void loadInvoiceDatesInComboBox()
        {
            try
            {
                //call our method in our clsSearchSQL file that gets all the dates in the database
                invoiceDatesArray = db.getInvoiceDates();

                //iterate through the list that the clsSearchSQL file populated
                foreach (Invoice invoice in invoiceDatesArray)
                {
                    //and put them in our combobox
                    InvoiceDateDropDown.Items.Add(invoice);

                }
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Private method that will load all our invoice costs initially when a user opens the search invoice window
        /// </summary>
        private void loadInvoiceCostsInComboBox()
        {
            try
            {
                //call our method in our clsSearchSQL file that gets all the dates in the database
                invoiceCostArray = db.getInvoiceCosts();

                //iterate through the list that the clsSearchSQL file populated
                foreach (Invoice invoice in invoiceCostArray)
                {
                    //and put them in our combobox
                    InvoiceTotalChargeDropDown.Items.Add(invoice);

                }
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }


        private void LoadInvoicesIntoDataGrid()
        {

        }
        #endregion
        #endregion

    }
}
