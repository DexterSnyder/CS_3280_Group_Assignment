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

        /// <summary>
        /// Item screen
        /// </summary>
        wndItems wndItems;

        wndSearch wndSearch; 

        /// <summary>
        /// Items specific to an invoice
        /// </summary>
        private ArrayList invoiceItems;

        /// <summary>
        /// All items
        /// </summary>
        private ArrayList allItems;

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
                wndItems = new wndItems();
                wndItems.Hide();
                invoiceItems = new ArrayList();
                allItems = new ArrayList();

                loadInvoices();
                loadItemComboBox();
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
                //TODO -> convert to the way it is done in the Advanced WPF Concepts video////////////////////////////////

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

        /// <summary>
        /// Refreshes the displayed invoices
        /// </summary>
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
        /// Refreshes the items in the select item box
        /// </summary>
        private void refreshItemComboBox()
        {
            try
            {
                //Clear item list
                //clear box
                for (int i = SelectItemBox.Items.Count - 1; i >= 0; --i)
                {
                    SelectItemBox.Items.RemoveAt(i);
                }

                //load with new values
                loadItemComboBox();
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// loads the items in the select item box
        /// </summary>
        private void loadItemComboBox()
        {
            try
            {
                //get the items
                allItems = db.getAllItems();

                //loop through and add them to the combo box
                foreach (Item item in allItems)
                {
                    SelectItemBox.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Load the list box with all the items in the invoice
        /// </summary>
        /// <param name="invoice">Invoice to search for</param>
        private void loadItemListBox (Invoice invoice)
        {
            try
            {
                //load the item list box
                invoiceItems = db.getInvoiceItems(invoice);
                foreach (Item item in invoiceItems)
                {
                    ItemListBox.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Clear and load ItemListBox
        /// </summary>
        private void refreshItemListBox(Invoice invoice)
        {
            try
            {
                //clear box
                for (int i = ItemListBox.Items.Count - 1; i >= 0; --i)
                {
                    ItemListBox.Items.RemoveAt(i);
                }

                //load
                loadItemListBox(invoice);
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

            try
            {
                //Hide the menu
                this.Hide();

                //Show the item form
                wndItems.ShowDialog();
                //Show the Items form
                this.Show();

                //Since the item database may have been updated
                //Clear out select item box and reload it
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
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
            try
            {
                Invoice temp = (Invoice)InvoiceListBox.SelectedItem;
                InvoiceNumberTextBox.Text = temp.InvoiceNumber.ToString();
                InvoiceDateTextBox.Text = temp.InvoiceDate;
                TotalCostTextBox.Text = temp.TotalCost.ToString();
                refreshItemListBox(temp);
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        ///<summary>
        ///Display the searched for invoiceID
        /// </summary>
        public void DisplaySearchedForInvoices(List<clsSearchLogic> lstInvoices)
        {
            try
            {


                //There are a couple ways we could implement this, but this will be passed from the button event

                //This is the interface method
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }


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
        /// <summary>
        /// Button click to remove an item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveItemButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                System.IO.File.AppendAllText("C:\\Error.txt", Environment.NewLine +
                                             "HandleError Exception: " + ex.Message);
            }
        }

        /// <summary>
        /// button to add a item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddItemButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                
            }
            catch (Exception ex)
            {
                System.IO.File.AppendAllText("C:\\Error.txt", Environment.NewLine +
                                             "HandleError Exception: " + ex.Message);
            }
        }
    }//class
}//namespace
