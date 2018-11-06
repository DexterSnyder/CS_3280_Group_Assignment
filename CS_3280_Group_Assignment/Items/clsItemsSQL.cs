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
        private clsDataAccess db = new clsDataAccess();

       

        private OleDbCommand cmd;

        private ArrayList items;


        /// <summary>
        /// initialize
        /// </summary>
        public clsItemsSQL()
        {
            try
            {
                items = new ArrayList();
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// get items
        /// </summary>
        /// <returns>items</returns>
        public ArrayList getItems()
        {
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

        public void createItems(Item toAdd)
        {
            int iRef = 0;
            string desc = toAdd.ItemDesc;
            string cost = toAdd.Cost.ToString();
            string query = "INSERT INTO Items(ItemDesc, Cost) Values(#" + desc + "#, " + cost + ");";

            iRef = db.ExecuteNonQuery(query);

        }


        public void updateItem(Item toUpdate)
        {
            int iRef = 0;
            string code = toUpdate.ItemCode.ToString();
            string desc = toUpdate.ItemDesc;
            string cost = toUpdate.Cost.ToString();
            string query = "UPDATE Item SET itemDesc = #" + desc + "#, Cost = " + cost + " " +
                "WHERE ItemCode = " + code + ";";

        }

    }
}
