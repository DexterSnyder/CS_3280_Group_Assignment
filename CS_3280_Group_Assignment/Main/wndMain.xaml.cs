using CS_3280_Group_Assignment.Items;
using CS_3280_Group_Assignment.Search;
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

namespace CS_3280_Group_Assignment.Main
{
    /// <summary>
    /// Interaction logic for wndMain.xaml
    /// </summary>
    public partial class wndMain : Window
    {
        /// <summary>
        /// If the user is editing an invoice
        /// </summary>
        private bool isEditing;

        /// <summary>
        /// If the user is adding an invoice
        /// </summary>
        private bool isAdding;

        /// <summary>
        /// A list of the invoices
        /// </summary>
        private ArrayList invoices;

        wndItems wndItems;

        wndSearch wndSearch; 

        /// <summary>
        /// an instance of the database
        /// </summary>
        private clsMainSQL db;

        

        public wndMain()
        {
            try
            {
                InitializeComponent();
                isEditing = false;
                isAdding = false;
                invoices = new ArrayList();
                db = new clsMainSQL();

                loadInvoices();
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Loads the invoices into the list box
        /// </summary>
        private void loadInvoices()
        {
            try
            {
                invoices = db.getInvoices();
                foreach (Invoice item in invoices)
                {
                    InvoiceListBox.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void refreshInvoices()
        {
            try
            {
                //Clear List box
                loadInvoices();
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Allows the user to edit the selected invoice
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditInvoiceButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                isEditing = true;
                //get selection
                //unlock text boxes
                refreshInvoices();
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Delete button click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteInvoiceButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //get selection
                //delete selection
                refreshInvoices();
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// New invoice button click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewInvoiceButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                isAdding = true;
                //unlock textboxes
                //set invoice number
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Save button click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //get the data
                if (isAdding)
                {
                    //send SQL
                    isAdding = false;
                    refreshInvoices();
                }
                if (isEditing)
                {
                    //send SQL
                    isEditing = false;
                    refreshInvoices();
                }
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Update button click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            wndItems = new wndItems();
            //Hide the menu
            this.Hide();
            //Show the Items form
            wndItems.ShowDialog();
            //Show the Items form
            this.Show();
        }

        /// <summary>
        /// Search button click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Search_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //open the search form
                wndSearch = new wndSearch();
                //Hide the menu
                this.Hide();
                //Show the search form
                wndSearch.ShowDialog();
                //Show the search form
                this.Show();
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                           MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// When the selected invoice changes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InvoiceListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Invoice temp = (Invoice)InvoiceListBox.SelectedItem;
            InvoiceNumberTextBox.Text = temp.InvoiceNumber.ToString();
            InvoiceDateTextBox.Text = temp.InvoiceDate;
            TotalCostTextBox.Text = temp.TotalCost.ToString();
        }


        ///<summary>
        ///RO RAGUE ADDED THIS: Display the searched for invoiceID
        /// </summary>
        public void DisplaySearchedForInvoices(List<clsSearchLogic> lstInvoices)
        {
            InvoiceListBox.ItemsSource = lstInvoices;
        }


        /// <summary>
        /// Close out application, since this is the main window of the application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                Application.Current.Shutdown();
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }
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




    }//class
}//namespace
