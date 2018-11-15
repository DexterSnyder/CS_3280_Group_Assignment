using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CS_3280_Group_Assignment.Search
{
    class clsSearchSQL
    {
        #region Variables/Lists/Objects

        /// <summary>
        /// a database access object to access our database
        /// </summary>
        private clsDataAccess db = new clsDataAccess();

        /// <summary>
        /// a OleDbCommand object to help with our SQL statements
        /// </summary>
        private OleDbCommand cmd;

        /// <summary>
        /// an Invoice object to help get some methods
        /// </summary>
        private Invoice inv; 

        /// <summary>
        /// Array Lists to help store our needed data for the Search Window Combo-boxes
        /// </summary>
        private ArrayList invoiceDates;
        private ArrayList invoiceIDs;
        private ArrayList invoiceCosts;

        #endregion

        /// <summary>
        /// initialize/constructor
        /// </summary>
        public clsSearchSQL()
        {
            try
            {
                //initialize our lists
                invoiceDates = new ArrayList();
                invoiceIDs = new ArrayList();
                invoiceCosts = new ArrayList();

                //initialize our Invoice inv
                inv = new Invoice(); 
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        #region Methods

        /// <summary>
        /// get our invoice IDS for our Search Window combo-box
        /// </summary>
        /// <returns>items</returns>
        public ArrayList getInvoiceIDs()
        {
            try
            {
                DataSet ds;
                int iRef = 0;

                //SQL Query to extract the Invoice ID from the INvoices table
                string query = "SELECT InvoiceNum FROM Invoices";

                ds = db.ExecuteSQLStatement(query, ref iRef);

                //iterate through all the rows
                for (int i = 0; i < iRef; i++)
                {
                    //get the invoice ID as a string
                    string sinvoiceID = ds.Tables[0].Rows[i]["InvoiceNum"].ToString();


                    //conver the invoice ID to an int
                    int invoiceID = Convert.ToInt32(sinvoiceID); 

                    //create an Invoice object
                    Invoice iID = new Invoice(invoiceID);

                    //add to our invoiceID list
                    invoiceIDs.Add(iID);
                }

                //return our list
                return invoiceIDs;

            }

            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);

            }
            
        }

        /// <summary>
        /// get invoice dates for our Search Window combo-box
        /// </summary>
        /// <returns>items</returns>
        public ArrayList getInvoiceDates()
        {
            try
            {
                DataSet ds;
                int iRef = 0;

                //SQL statement to extrace the Invoice date from the Invoices table
                string query = "SELECT InvoiceDate FROM Invoices";

                ds = db.ExecuteSQLStatement(query, ref iRef);

                //iterate through all the rows
                for (int i = 0; i < iRef; i++)
                {
                    //get the invoice date as a string
                    string invoiceDate = ds.Tables[0].Rows[i]["InvoiceDate"].ToString();
                    
                    //create an Invoice object out of the invoice date
                    Invoice iDate = new Invoice(invoiceDate);

                    //add the date to our invoice dates list
                    invoiceDates.Add(iDate);
                }

                //return our list
                return invoiceDates;
            }

            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);

            }
            
        }

        /// <summary>
        /// get invoice costs
        /// </summary>
        /// <returns>items</returns>
        public ArrayList getInvoiceCosts()
        {
            try
            {
                DataSet ds;
                int iRef = 0;

                //query to get all the invoice total costs from the Invoices table
                string query = "SELECT TotalCost FROM Invoices";

                ds = db.ExecuteSQLStatement(query, ref iRef);

                //iterate through the rows
                for (int i = 0; i < iRef; i++)
                {
                    //get the invoice cost as a string
                    string sinvoiceCost = (ds.Tables[0].Rows[i]["TotalCost"]).ToString();

                    
                    //convert the invoice cost to a double
                    double invoiceCost = Convert.ToDouble(sinvoiceCost);

                    //create an Invoice object
                    Invoice iCost = new Invoice(invoiceCost);

                    

                    //add the object to our invoice costs list
                    invoiceCosts.Add(iCost);
                }

                //return our list
                return invoiceCosts; 

            }

            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);

            }
            
        }



#endregion
    }
}
