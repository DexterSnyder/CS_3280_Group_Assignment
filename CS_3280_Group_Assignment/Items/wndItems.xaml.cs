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

namespace CS_3280_Group_Assignment.Items
{
    /// <summary>
    /// Interaction logic for wndItems.xaml
    /// </summary>
    public partial class wndItems : Window
    {
        /// <summary>
        /// items logic
        /// </summary>
        private clsItemsLogic itemLogic;

        /// <summary>
        /// If the user is editing an invoice
        /// </summary>
        private bool isEditing;
        /// <summary>
        /// an Item
        /// </summary>
        private Item item;

        /// <summary>
        /// If the user is adding an invoice
        /// </summary>
        private bool isAdding;

        /// <summary>
        /// if the user is deleting or not
        /// </summary>
        private bool isDeleting;
        /// <summary>
        /// Initializer
        /// </summary>
        public wndItems()
        {
            try
            {
                InitializeComponent();

                isEditing = false;
                isAdding = false;
                isDeleting = false;
                itemLogic = new clsItemsLogic();
                item = new Item();
                ItemCodeTextBox.IsEnabled = false;
                ItemDescriptionTextBox.IsEnabled = false;
                ItemCostTextBox.IsEnabled = false;
                loadItems();
            }

            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }



        }
        /// <summary>
        /// load the items on the data grid
        /// </summary>
        private void loadItems()
        {
            try
            {
                
                 ItemDataGrid.ItemsSource = itemLogic.items;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }


        /// <summary>
        /// add new items button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddNewItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                isAdding = true;
                ItemCodeTextBox.IsEnabled = true;
                ItemDescriptionTextBox.IsEnabled = true;
                ItemCostTextBox.IsEnabled = true;
                item.ItemCode = "";
                item.ItemDesc = "";
                item.Cost = 0;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        /// <summary>
        /// when the edit item button is pressed enables the user to enter edit item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditItemButton_Click(object sender, RoutedEventArgs e)
        {
            if (ItemDataGrid.SelectedIndex == -1)
            {
                MessageBox.Show("Please select an item to edit before clicking");
            }
            else
            {
                isEditing = true;
                Item editItem = (Item)ItemDataGrid.SelectedItem;
                ItemCodeTextBox.Text = editItem.ItemCode;
                ItemDescriptionTextBox.Text = editItem.ItemDesc;
                ItemCostTextBox.Text = editItem.Cost.ToString();
                ItemDescriptionTextBox.IsEnabled = true;
                ItemCostTextBox.IsEnabled = true;
            }
            
        }
        /// <summary>
        /// delete an item action
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteItemButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ItemDataGrid.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select an item to delete before clicking");
                }
                else
                {
                    isDeleting = true;
                    Item deleteItem = (Item)ItemDataGrid.SelectedItem;
                    ItemCodeTextBox.Text = deleteItem.ItemCode;
                    ItemDescriptionTextBox.Text = deleteItem.ItemDesc;
                    ItemCostTextBox.Text = deleteItem.Cost.ToString();
                }
                
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Save click button method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(ItemCodeTextBox.Text == ""  || ItemCostTextBox.Text == "" || ItemDescriptionTextBox.Text == "")
                {
                    MessageBox.Show("Please provide an input for all textboxes");
                    return;
                }
                
                if (isAdding)
                {
                    Item item = new Item();
                    isAdding = false;
                    item.ItemCode = ItemCodeTextBox.Text;
                    item.ItemDesc = ItemDescriptionTextBox.Text;
                    item.Cost = Convert.ToDouble(ItemCostTextBox.Text);
                    string anID = itemLogic.checkId(item);
                    if(anID == "")
                    {
                        itemLogic.addNewItem(item);
                        

                        loadItems();
                    }
                    else
                    {
                        isAdding = true;
                        MessageBox.Show("The Code you picked is already in use");
                        return;
                    }
                   
                }
                if (isEditing)
                {
                    Item editItem = (Item)ItemDataGrid.SelectedItem;
                    isEditing = false;
                    string tempCode = editItem.ItemCode;
                    editItem.ItemDesc = ItemDescriptionTextBox.Text;
                    editItem.Cost = Convert.ToDouble(ItemCostTextBox.Text);
                    itemLogic.EditItem(editItem, tempCode);
                    
                }

                if (isDeleting)
                {
                    Item deleteItem = (Item)ItemDataGrid.SelectedItem;
                    string deleteM = itemLogic.checkInvoiceItem(deleteItem);
                    if(deleteM == "")
                    {
                        itemLogic.removeItem(deleteItem);
                    }
                    else
                    {
                        MessageBox.Show(deleteM);
                    }
                    isDeleting = false;
                    
                }
                ItemCodeTextBox.IsEnabled = false;
                ItemDescriptionTextBox.IsEnabled = false;
                ItemCostTextBox.IsEnabled = false;
                ItemCodeTextBox.Text = "";
                ItemDescriptionTextBox.Text = "";
                ItemCostTextBox.Text = "";
                itemLogic.getItems();
                loadItems();
                
            }

            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// When the selected item changes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ItemDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Item temp = (Item)ItemDataGrid.SelectedItem;
            ItemCodeTextBox.Text = temp.ItemCode.ToString();
            ItemDescriptionTextBox.Text = temp.ItemDesc;
            ItemCostTextBox.Text = temp.Cost.ToString();
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
        /// Cancel click method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cancel_Click(object sender, RoutedEventArgs e) {

            ItemCodeTextBox.IsEnabled = false;
            ItemDescriptionTextBox.IsEnabled = false;
            ItemCostTextBox.IsEnabled = false;
            isDeleting = false;
            isEditing = false;
            isAdding = false;
            ItemCodeTextBox.Text = "";
            ItemDescriptionTextBox.Text = "";
            ItemCostTextBox.Text = "";
        }
    }
}
