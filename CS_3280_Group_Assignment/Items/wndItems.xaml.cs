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
        /// database access
        /// </summary>
        private clsItemsSQL db;

        /// <summary>
        /// list of items
        /// </summary>
        private ArrayList items;


        /// <summary>
        /// If the user is editing an invoice
        /// </summary>
        private bool isEditing;

        /// <summary>
        /// If the user is adding an invoice
        /// </summary>
        private bool isAdding;
        public wndItems()
        {
            try
            {
                InitializeComponent();

                isEditing = false;
                isAdding = false;
                items = new ArrayList();
                db = new clsItemsSQL();

                loadItems();
            }

            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }



        }

        private void loadItems()
        {
            try
            {
                items = db.getItems();
                foreach (Item item in items)
                {
                    ItemDataGrid.Items.Add(item);

                }
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// refresh items
        /// </summary>
        private void refreshItems()
        {
            try
            {
                loadItems();
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

            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        private void EditItemButton_Click(object sender, RoutedEventArgs e)
        {


        }

        private void DeleteItemButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //get selection
                //delete selection
                refreshItems();
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //get the data
                if (isAdding)
                {
                    //send SQL
                    isAdding = false;
                    refreshItems();
                }
                if (isEditing)
                {
                    //send SQL
                    isEditing = false;
                    refreshItems();
                }
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
    }
}
