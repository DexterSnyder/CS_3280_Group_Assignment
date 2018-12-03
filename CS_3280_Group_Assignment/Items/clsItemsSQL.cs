using System;
using System.Collections.Generic;
using System.Data;
using System.Collections.ObjectModel;
using System.Data.OleDb;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace CS_3280_Group_Assignment.Items
{
    class clsItemsSQL
    {

        /// <summary>
        /// initialize
        /// </summary>
        public clsItemsSQL()
        {
            try
            {
                
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// get items from database
        /// </summary>
        /// <returns>items</returns>
        public ObservableCollection<Item> getItems()
        {
            ObservableCollection<Item> items = new ObservableCollection<Item>();
            clsDataAccess db = new clsDataAccess();
            try
            {
                DataSet ds;

                int iRef = 0;
                string query = "SELECT ItemCode, ItemDesc, Cost FROM ItemDesc";

                ds = db.ExecuteSQLStatement(query, ref iRef);

                for (int i = 0; i < iRef; i++)
                {
                    string itemCode = ds.Tables[0].Rows[i]["ItemCode"].ToString();
                    string itemDesc = ds.Tables[0].Rows[i]["ItemDesc"].ToString();
                    string cost = ds.Tables[0].Rows[i]["Cost"].ToString();
                    Item item = new Item(itemCode, itemDesc, Convert.ToDouble(cost));
                    items.Add(item);
                }
                

            }

            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);

            }
            return items;
        }
        /// <summary>
        /// insert item in database
        /// </summary>
        /// <param name="item"></param>
        public void insertItems(Item item)
        {
            try
            {
                clsDataAccess db = new clsDataAccess();
                int iRef = 0;
                string code = item.ItemCode;
                string desc = item.ItemDesc;
                string cost = item.Cost.ToString();
                string query = "INSERT INTO ItemDesc(ItemCode, ItemDesc, Cost) Values('" + code + "', '" + desc + "' , '" + cost + "' );";

                iRef = db.ExecuteNonQuery(query);
            }
            catch (Exception ex)
            {
                System.IO.File.AppendAllText("C:\\Error.txt", Environment.NewLine +
                                             "HandleError Exception: " + ex.Message);
            }

        }
        /// <summary>
        /// delete item from database
        /// </summary>
        /// <param name="deleteItem"></param>
        public void deletedItem(Item deleteItem)
        {
            try
            {
                clsDataAccess db = new clsDataAccess();
                int iRef = 0;
                string code = deleteItem.ItemCode;
                string deleteQuery;
                deleteQuery = "DELETE FROM ItemDesc WHERE ItemCode = '" + code + "';";
                iRef = db.ExecuteNonQuery(deleteQuery);
            }

            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        /// <summary>
        /// select used items in invoices from database
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public List<int> checkInvoice(Item item)
        {
            clsDataAccess db = new clsDataAccess();
            List<int> invoiceNums = new List<int>();
            string code = item.ItemCode;
            DataSet ds = new DataSet();
            string checkin;
            int retVal = 0;
            checkin = "SELECT DISTINCT InvoiceNum FROM LineItems WHERE ItemCode = '" +  code + "';";
            ds = db.ExecuteSQLStatement(checkin, ref retVal);
            foreach(DataRow dr in ds.Tables[0].Rows)
            {
                invoiceNums.Add(Convert.ToInt32(dr[0]));
            }
            return invoiceNums;
        }
        /// <summary>
        /// check if item code is already used
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public string checkId(Item item)
        {
            try
            {
                clsDataAccess db = new clsDataAccess();
                string code = item.ItemCode;
                string checkid;
                checkid = "SELECT ItemCode FROM ItemDesc WHERE ItemCode = '" + code + "';";
                string result = db.ExecuteScalarSQL(checkid);
                return result;
            }

            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
            

        }
        /// <summary>
        /// update item in database
        /// </summary>
        /// <param name="toUpdate"></param>
        /// <param name="oldCode"></param>
        public void updateItem(Item toUpdate, string oldCode)
        {
            try
            {
                clsDataAccess db = new clsDataAccess();
                int iRef = 0;
                string code = toUpdate.ItemCode;
                string desc = toUpdate.ItemDesc;
                string cost = toUpdate.Cost.ToString();
                string query = "UPDATE ItemDesc SET ItemCode = '" + code + "', ItemDesc = '" + desc + "', Cost = '" + cost + "' " +
                    "WHERE ItemCode = '" + code + "';";
                iRef = db.ExecuteNonQuery(query);
            }
            catch (Exception ex)
            {
                System.IO.File.AppendAllText("C:\\Error.txt", Environment.NewLine +
                                             "HandleError Exception: " + ex.Message);
            }

        }

    }
}
