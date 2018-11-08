using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_3280_Group_Assignment.Main
{
    class clsMainSQL
    {
        /// <summary>
        /// Instance to access the database
        /// </summary>
        clsDataAccess db = new clsDataAccess();

        /// <summary>
        /// default constructor
        /// </summary>
        public clsMainSQL()
        {
            try
            {

            }
            catch (Exception ex)
            {
                System.IO.File.AppendAllText("C:\\Error.txt", Environment.NewLine +
                                             "HandleError Exception: " + ex.Message);
            }
        }//constructor
        public ArrayList getInvoices()
        {
            ArrayList invoices = new ArrayList();

            try
            { 
                //set up for query
                DataSet ds;
                int iRef = 0;
                string query = "SELECT InvoiceNum, InvoiceDate, TotalCost FROM Invoices";

                //execute query
                ds = db.ExecuteSQLStatement(query, ref iRef);

                //create and store objects
                for (int i = 0; i < iRef; i++)
                {
                    string invoiceNum = ds.Tables[0].Rows[i]["InvoiceNum"].ToString();
                    string invoiceDate = ds.Tables[0].Rows[i]["InvoiceDate"].ToString();
                    string totalCost = ds.Tables[0].Rows[i]["TotalCost"].ToString();
                    Invoice invoice = new Invoice(Int32.Parse(invoiceNum), invoiceDate, Convert.ToDouble(totalCost));
                    invoices.Add(invoice);
                }
            }
            catch (Exception ex)
            {
                System.IO.File.AppendAllText("C:\\Error.txt", Environment.NewLine +
                                             "HandleError Exception: " + ex.Message);
            }
            return invoices;
        }

        /// <summary>
        /// Add an invoice to the database
        /// </summary>
        /// <param name="toAdd">invoice to add</param>
        public void createInvoice(Invoice toAdd)
        {
            //set up query
            int iRef = 0;
            string date = toAdd.InvoiceDate;
            string cost = toAdd.TotalCost.ToString();
            string query = "INSERT INTO Invoices(InvoiceDate, TotalCost) Values(#" + date + "#, " + cost + ");";

            //execute
            iRef = db.ExecuteNonQuery(query);
        }

        /// <summary>
        /// updates an invoice
        /// </summary>
        /// <param name="toUpdate">Invoice to update</param>
        public void updateInvoice(Invoice toUpdate)
        {
            //set up query
            int iRef = 0;
            string date = toUpdate.InvoiceDate;
            string cost = toUpdate.TotalCost.ToString();
            string number = toUpdate.InvoiceNumber.ToString();
            string query = "UPDATE Invoices SET InvoiceDate = #" + date + "#, TotalCost = " + cost + " " +
                "WHERE InvoiceNum = " + number + ";";
        }

        public ArrayList getInvoiceItems(Invoice invoice)
        {
            ArrayList items = new ArrayList();

            try
            {
                //set up query
                DataSet ds;
                int iRef = 0;
                string query = "SELECT  ItemDesc.ItemCode, ItemDesc, Cost " +
                                "FROM LineItems INNER JOIN ItemDesc "+
                                "ON LineItems.ItemCode = ItemDesc.ItemCode "+
                                "WHERE InvoiceNum = "+invoice.InvoiceNumber+"; ";
                
                //execute
                ds = db.ExecuteSQLStatement(query, ref iRef);

                //assign objects
                for (int i = 0; i < iRef; i++)
                {
                    string code = ds.Tables[0].Rows[i]["ItemCode"].ToString();
                    string description = ds.Tables[0].Rows[i]["ItemDesc"].ToString();
                    double cost = Int32.Parse(ds.Tables[0].Rows[i]["Cost"].ToString());
                    Item item = new Item(code, description, cost);
                    items.Add(item);
                }

            }
            catch (Exception ex)
            {
                System.IO.File.AppendAllText("C:\\Error.txt", Environment.NewLine +
                                             "HandleError Exception: " + ex.Message);
            }
            return items;
        }

        public ArrayList getAllItems ()
        {
            ArrayList allItems = new ArrayList();

            
            //set up query
            DataSet ds;
            int iRef = 0;
            string query = "SELECT  ItemCode, ItemDesc, Cost FROM ItemDesc;";

            //execute
            ds = db.ExecuteSQLStatement(query, ref iRef);

            //assign objects
            for (int i = 0; i < iRef; i++)
            {
                string code = ds.Tables[0].Rows[i]["ItemCode"].ToString();
                string description = ds.Tables[0].Rows[i]["ItemDesc"].ToString();
                double cost = Int32.Parse(ds.Tables[0].Rows[i]["Cost"].ToString());
                Item item = new Item(code, description, cost);
                allItems.Add(item);
            }

            return allItems;
        }
    }//class
}//namespace
