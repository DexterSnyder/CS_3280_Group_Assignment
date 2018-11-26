using CS_3280_Group_Assignment.Items;
using CS_3280_Group_Assignment.Search;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        /// Item screen
        /// </summary>
        private wndItems wndItems;

        /// <summary>
        /// Search Screen
        /// </summary>
        private wndSearch wndSearch;

        /// <summary>
        /// The current working copy of an invoice
        /// </summary>
        private Invoice workingInvoice;

        /// <summary>
        /// Buisness logic
        /// </summary>
        private clsMainLogic logic;

        public wndMain()
        {
            try
            {
                InitializeComponent();
                isEditing = false;
                isAdding = false;
                wndItems = new wndItems();
                wndItems.Hide();
                workingInvoice = new Invoice();
                logic = new clsMainLogic();

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
                //Bind GUI to the list in the logic portion
                InvoiceListBox.ItemsSource = logic.invoices;
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

                //Bind all items list in logic to GUI  
                SelectItemBox.ItemsSource = logic.allItems;
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
                //Reset the list in the logic
                logic.getInvoiceItems(invoice);

                //bind list in logic to the GUI
                ItemListBox.ItemsSource = logic.invoiceItems;
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
                //unlock text boxes and buttons
                AddItemButton.IsEnabled = true;
                RemoveItemButton.IsEnabled = true;
                SaveButton.IsEnabled = true;
                InvoiceDateTextBox.IsReadOnly = false;
                SelectItemBox.IsEnabled = true;

                //Lock controls
                NewInvoiceButton.IsEnabled = false;
                DeleteInvoiceButton.IsEnabled = false;
                EditInvoiceButton.IsEnabled = false;
                InvoiceListBox.IsEnabled = false;

                //set working invoice equal to currently selected
                workingInvoice = (Invoice)InvoiceListBox.SelectedItem;
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
                loadInvoices();
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
                //unlock UI controls
                AddItemButton.IsEnabled = true;
                RemoveItemButton.IsEnabled = true;
                SaveButton.IsEnabled = true;
                InvoiceDateTextBox.IsReadOnly = false;
                SelectItemBox.IsEnabled = true;

                //Lock controls
                NewInvoiceButton.IsEnabled = false;
                DeleteInvoiceButton.IsEnabled = false;
                EditInvoiceButton.IsEnabled = false;
                InvoiceListBox.IsEnabled = false;

                //set up text boxes
                InvoiceNumberTextBox.Text = "TBD";
                InvoiceDateTextBox.Text = "";

                //clear out items
                logic.invoiceItems.Clear();

                //Clear out the working invoice
                workingInvoice.TotalCost = 0;
                workingInvoice.InvoiceNumber = 0;
                workingInvoice.InvoiceDate = "";

                isAdding = true;
                
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
                //if the user is adding a new invoice
                if (isAdding)
                {
                    //save to the database
                    logic.saveNewInvoice(workingInvoice);
                    isAdding = false;
                    loadInvoices();
                }
                if (isEditing)
                {
                    //update the database
                    logic.updateInvoice(workingInvoice);
                    isEditing = false;
                    loadInvoices();
                }

                //Lock UI controls
                AddItemButton.IsEnabled = false;
                RemoveItemButton.IsEnabled = false;
                SaveButton.IsEnabled = false;
                InvoiceDateTextBox.IsReadOnly = true;
                SelectItemBox.IsEnabled = false;

                //unlock UI controls
                NewInvoiceButton.IsEnabled = true;
                DeleteInvoiceButton.IsEnabled = true;
                EditInvoiceButton.IsEnabled = true;
                InvoiceListBox.IsEnabled = true;
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
                loadItemListBox(temp);
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
                //get the selected item
                Item temp = (Item)ItemListBox.SelectedItem;

                //remove it
                logic.invoiceItems.Remove(temp);

                workingInvoice.TotalCost = logic.calcTotalCost();
                TotalCostTextBox.Text = workingInvoice.TotalCost.ToString();
                
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
                //get the selected item
                Item temp = (Item)SelectItemBox.SelectedItem;

                //remove it
                logic.invoiceItems.Add(temp);

                workingInvoice.TotalCost = logic.calcTotalCost();
                TotalCostTextBox.Text = workingInvoice.TotalCost.ToString();

            }
            catch (Exception ex)
            {
                System.IO.File.AppendAllText("C:\\Error.txt", Environment.NewLine +
                                             "HandleError Exception: " + ex.Message);
            }
        }
    }//class
}//namespace
