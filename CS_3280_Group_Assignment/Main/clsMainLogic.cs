using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_3280_Group_Assignment.Main
{
    class clsMainLogic
    {

        //Public Variables
        /// <summary>
        /// A list of the invoices
        /// </summary>
        public  ObservableCollection<Invoice> invoices;

        /// <summary>
        /// Items specific to an invoice
        /// </summary>
        public ObservableCollection<Item> invoiceItems;

        /// <summary>
        /// All items
        /// </summary>
        public ObservableCollection<Item> allItems;

        /// <summary>
        /// an instance of the database
        /// </summary>
        private clsMainSQL db;

        public clsMainLogic ()
        {
            invoices = new ObservableCollection<Invoice>();
            db = new clsMainSQL();
            invoiceItems = new ObservableCollection<Item>();
            allItems = new ObservableCollection<Item>();

            //set up the data
            getInvoices();
            getAllItems();
        }

        /// <summary>
        /// Get invoices from the database
        /// </summary>
        public void getInvoices()
        {
            try
            {
                invoices = db.getInvoices();
            }
            catch (Exception ex)
            {
                System.IO.File.AppendAllText("C:\\Error.txt", Environment.NewLine +
                                             "HandleError Exception: " + ex.Message);
            }
        }

        /// <summary>
        /// Get a list of all items from the database
        /// </summary>
        public void getAllItems()
        {
            try
            {
                allItems = db.getAllItems();
            }
            catch (Exception ex)
            {
                System.IO.File.AppendAllText("C:\\Error.txt", Environment.NewLine +
                                             "HandleError Exception: " + ex.Message);
            }
        }

        /// <summary>
        /// Get items related to a specfic invoice from the database
        /// </summary>
        /// <param name="invoice"></param>
        public void getInvoiceItems(Invoice invoice)
        {
            try
            {
                invoiceItems = db.getInvoiceItems(invoice);
            }
            catch (Exception ex)
            {
                System.IO.File.AppendAllText("C:\\Error.txt", Environment.NewLine +
                                             "HandleError Exception: " + ex.Message);
            }
        }
        
        /// <summary>
        /// Save a new invoice to the database
        /// </summary>
        /// <param name="invoice">Invoice to sace</param>
        /// <returns>The ID of the new invoice</returns>
        public int saveNewInvoice (Invoice invoice)
        {
            int invoiceId = 0;
            try
            {
                db.addNewInvoice(invoice, invoiceItems); 
            }
            catch (Exception ex)
            {
                System.IO.File.AppendAllText("C:\\Error.txt", Environment.NewLine +
                                             "HandleError Exception: " + ex.Message);
            }
            return invoiceId;
        }

        /// <summary>
        /// Updates a specific invoice with the items in the invoice items list
        /// </summary>
        /// <param name="invoice">Invoice to update</param>
        public void updateInvoice(Invoice invoice)
        {
            try
            {
                db.updateInvoice(invoice, invoiceItems);
            }
            catch (Exception ex)
            {
                System.IO.File.AppendAllText("C:\\Error.txt", Environment.NewLine +
                                             "HandleError Exception: " + ex.Message);
            }
        }

        /// <summary>
        /// Calculats the total cost of the selected invoice
        /// </summary>
        /// <returns></returns>
        public double calculateTotalCost()
        {
            double total = 0;

            try
            {
                //loop over items and total
                foreach (Item item in invoiceItems)
                {
                    total += item.Cost;
                }
            }
            catch (Exception ex)
            {
                System.IO.File.AppendAllText("C:\\Error.txt", Environment.NewLine +
                                             "HandleError Exception: " + ex.Message);
            }
            return total;
        }

        public void deleteInvoice(Invoice invoice)
        {
            try
            {
                //remove from the list
                invoices.Remove(invoice);

                //delete from database
                db.deleteInvoice(invoice);

                //clear items
                invoiceItems.Clear();
            }
            catch (Exception ex)
            {
                System.IO.File.AppendAllText("C:\\Error.txt", Environment.NewLine +
                                             "HandleError Exception: " + ex.Message);
            }
        }
    }//class
}//namespace
