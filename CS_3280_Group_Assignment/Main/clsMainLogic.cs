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

        public void getInvoices()
        {
            invoices = db.getInvoices();
        }

        public void getAllItems()
        {
            allItems = db.getAllItems();
        }

        public void getInvoiceItems(Invoice invoice)
        {
            invoiceItems = db.getInvoiceItems(invoice);
        }
        
    
    }
}
