using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CS_3280_Group_Assignment.Items
{
    class clsItemsLogic
    {
        /// <summary>
        /// collection of items
        /// </summary>
        public ObservableCollection<Item> items;

        /// <summary>
        /// items sql methods
        /// </summary>
        private clsItemsSQL db;

        /// <summary>
        /// Initializer
        /// </summary>
        public clsItemsLogic()
        {
            items = new ObservableCollection<Item>();
            db = new clsItemsSQL();
            getItems();
            
        }

        /// <summary>
        /// call get items SQL
        /// </summary>
        public void getItems()
        {
            try
            {
                items = db.getItems();
            }

            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        /// <summary>
        /// call add new items SQL
        /// </summary>
        /// <param name="item"></param>
        public void addNewItem(Item item)
        {
            try
            {
                db.insertItems(item);
            }

            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// grab invoices that items are already using
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public string checkInvoiceItem(Item item)
        {
            List<int> invoices = db.checkInvoice(item);
            if (invoices.Count == 0)
                return "";
            string message = "Cannot delete, the item exists on the following invoices: ";
            foreach(int i in invoices)
            {
                message += " " + i;
            }
            return message;
        }

        /// <summary>
        /// check if id is already used
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public string checkId(Item item)
        {
            try
            {
                string id = db.checkId(item);
                return id;

            }

            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// call edit item sql
        /// </summary>
        /// <param name="item"></param>
        /// <param name="oldCode"></param>
        public void EditItem(Item item, string oldCode)
        {
            try
            {
                db.updateItem(item, oldCode);
            }

            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        /// <summary>
        /// call delete item sql
        /// </summary>
        /// <param name="deleteItem"></param>
        public void removeItem(Item deleteItem)
        {
            
            db.deletedItem(deleteItem);
            items.Remove(deleteItem);
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
