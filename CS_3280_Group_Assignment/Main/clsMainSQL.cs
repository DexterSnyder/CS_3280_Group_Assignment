using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public ObservableCollection<Invoice> getInvoices()

        {
            ObservableCollection<Invoice> invoices = new ObservableCollection<Invoice>();

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
        public void createInvoice (Invoice toAdd)
        {
            try
            {
                //set up query
                int iRef = 0;
                string date = toAdd.InvoiceDate;
                string cost = toAdd.TotalCost.ToString();
                string query = "INSERT INTO Invoices(InvoiceDate, TotalCost) Values(#" + date + "#, " + cost + ");";

                //execute
                iRef = db.ExecuteNonQuery(query);
            }
            catch (Exception ex)
            {
                System.IO.File.AppendAllText("C:\\Error.txt", Environment.NewLine +
                                             "HandleError Exception: " + ex.Message);
            }
        }

        /// <summary>
        /// updates an invoice
        /// </summary>
        /// <param name="toUpdate">Invoice to update</param>
        public void updateInvoice(Invoice toUpdate)
        {
            try
            {

                //set up query
                int iRef = 0;
                string date = toUpdate.InvoiceDate;
                string cost = toUpdate.TotalCost.ToString();
                string number = toUpdate.InvoiceNumber.ToString();

                string query = "UPDATE Invoices SET InvoiceDate = #" + date + "#, TotalCost = " + cost + " " +
                    "WHERE InvoiceNum = " + number + ";";
            }
            catch (Exception ex)
            {
                System.IO.File.AppendAllText("C:\\Error.txt", Environment.NewLine +
                                             "HandleError Exception: " + ex.Message);
            }
        }

        /// <summary>
        /// Gets all items related to specfic invoice
        /// </summary>
        /// <param name="invoice">The invoice to get items for</param>
        /// <returns>List of items</returns>
        public ObservableCollection<Item> getInvoiceItems(Invoice invoice)
        {
            ObservableCollection<Item> items = new ObservableCollection<Item>();

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

        /// <summary>
        /// Get all items in the database
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<Item> getAllItems ()
        {
            ObservableCollection<Item> allItems = new ObservableCollection<Item>();
            try
            {
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
            }
            catch (Exception ex)
            {
                System.IO.File.AppendAllText("C:\\Error.txt", Environment.NewLine +
                                             "HandleError Exception: " + ex.Message);
            }
            return allItems;
        }

        //---------------------------------------------------------------------------------------------------------------------------------------------

        /// <summary>
        /// Add a new invoice with line items to the database
        /// </summary>
        /// <param name="invoice">The invoice to add</param>
        /// <param name="items">The items to add</param>
        /// <returns>New Invoice ID</returns>
        public int addNewInvoice (Invoice invoice, ObservableCollection<Item> items)
        {
            int newInvoiceNumber = 0;
            try
            {
                int iRef = 0;
                DataSet ds;
                string query = "";

                //insert the invoice
                query = "INSERT INTO PASSENGER() VALUES('')";

                iRef = db.ExecuteNonQuery(query);

                //Get the ID back


                //insert the line Items
                query = "INSERT INTO PASSENGER() VALUES('')";

                iRef = db.ExecuteNonQuery(query);

            }
            catch (Exception ex)
            {
                System.IO.File.AppendAllText("C:\\Error.txt", Environment.NewLine +
                                             "HandleError Exception: " + ex.Message);
            }
            return newInvoiceNumber;
        }

        /// <summary>
        /// Updates the line items of a specific invoice
        /// </summary>
        /// <param name="invoice">Invoice to update</param>
        /// <param name="items">New item list</param>
        public void updateInvoice(Invoice invoice, ObservableCollection<Item> items)
        {
            try
            {
                int iRef = 0;
                DataSet ds;
                string query = "";

                //Delete the existing line item records that match the invoice ID

                //Insert new records from the items list

                iRef = db.ExecuteNonQuery(query);
            }
            catch (Exception ex)
            {
                System.IO.File.AppendAllText("C:\\Error.txt", Environment.NewLine +
                                             "HandleError Exception: " + ex.Message);
            }
        }
    }//class
}//namespace
