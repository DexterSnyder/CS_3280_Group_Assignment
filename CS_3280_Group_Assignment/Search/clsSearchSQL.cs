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

        private clsDataAccess db = new clsDataAccess();

        private OleDbCommand cmd;

        private ArrayList invoiceDates;
        private ArrayList invoiceIDs;
        private ArrayList invoiceCosts;


        /// <summary>
        /// initialize
        /// </summary>
        public clsSearchSQL()
        {
            try
            {
                invoiceDates = new ArrayList();
                invoiceIDs = new ArrayList();
                invoiceCosts = new ArrayList(); 
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
        public ArrayList getInvoiceIDs()
        {
            try
            {
                DataSet ds;

                int iRef = 0;
                string query = "SELECT InvoiceNum FROM Invoices";

                ds = db.ExecuteSQLStatement(query, ref iRef);

                for (int i = 0; i < iRef; i++)
                {
                    string sinvoiceID = ds.Tables[0].Rows[i]["InvoiceNum"].ToString();
                    int invoiceID = Convert.ToInt32(sinvoiceID); 
                    Invoice iID = new Invoice(invoiceID);
                    invoiceIDs.Add(iID);
                }


            }

            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);

            }
            return invoiceIDs;
        }

        /// <summary>
        /// get items
        /// </summary>
        /// <returns>items</returns>
        public ArrayList getInvoiceDates()
        {
            try
            {
                DataSet ds;

                int iRef = 0;
                string query = "SELECT InvoiceDate FROM Invoices";

                ds = db.ExecuteSQLStatement(query, ref iRef);

                for (int i = 0; i < iRef; i++)
                {
                    string invoiceDate = ds.Tables[0].Rows[i]["InvoiceDate"].ToString();

                    Invoice iDate = new Invoice(invoiceDate);
                    invoiceDates.Add(iDate);
                }
                

            }

            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);

            }
            return invoiceDates;
        }

        /// <summary>
        /// get items
        /// </summary>
        /// <returns>items</returns>
        public ArrayList getInvoiceCosts()
        {
            try
            {
                DataSet ds;

                int iRef = 0;
                string query = "SELECT TotalCost FROM Invoices";

                ds = db.ExecuteSQLStatement(query, ref iRef);

                for (int i = 0; i < iRef; i++)
                {
                    string sinvoiceCost = ds.Tables[0].Rows[i]["TotalCost"].ToString();

                    double invoiceCost = Convert.ToDouble(sinvoiceCost);

                    Invoice iCost = new Invoice(invoiceCost);
                    invoiceCosts.Add(iCost);
                }
                return invoiceCosts; 

            }

            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);

            }
            return invoiceDates;
        }
    }
}
