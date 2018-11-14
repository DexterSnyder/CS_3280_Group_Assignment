using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_3280_Group_Assignment.Search
{
    public class clsSearchLogic
    {
        #region Attributes

        ///<summary>
        ///invoiceID attribute to store our invoice ID number
        /// </summary>
        private int invoiceID;

        ///<summary>
        ///invoiceDate attribute to store our invoice date
        /// </summary>
        private DateTime invoiceDate;

        ///<summary>
        ///invoiceCharge attribute to store our invoice charge
        /// </summary>
        private double invoiceCharge;

        #endregion

        #region Methods


        /// <summary>
        /// clsSearchLogic constructor: another clsSearchLogic object supplied as an argument
        /// </summary>
        /// <param name="invoice"></param>
        public clsSearchLogic(clsSearchLogic invoice) : this(invoice.InvoiceID, invoice.InvoiceDate, invoice.InvoiceCharge) { }

        /// <summary>
        /// setting our invoiceID as a clsSearchLogic object
        /// </summary>
        /// <param name="invoiceID"></param>
        public clsSearchLogic(int invoiceI, DateTime invoiceD, double invoiceC)
        {
            this.invoiceID = invoiceI;
            this.invoiceDate = invoiceD;
            this.invoiceCharge = invoiceC; 
        }

        /// <summary>
        /// Generic constructor with no parameters passed 
        /// </summary>
        public clsSearchLogic()
        {
        }


        ///<summary>
        /// Function to initially populate our DataGrid when we first open the Search window
        /// Basic constructor
        /// </summary>
        public List<clsSearchLogic> GetSearchedInvoices(){

            List<clsSearchLogic> lstInvoices = new List<clsSearchLogic>();

            //grab the data from our database initially to display in the DataGrid
            //lstInvoices.Add(new clsSearchLogic { invoiceID, invoiceDate, invoiceCharge}); 

            return lstInvoices;   
         }

        /// <summary>
        /// Function to set the data retrieved by the value (row/invoice) selected in the Search window
        /// </summary>
        /// <param name="invoiceID">this is the int number for the invoiceID</param>
        /// <param name="invoiceDate">this is the datetime for the invoice date</param>
        /// <param name="invoiceCharge">this is the double for the invoice charge</param>
        /// <returns></returns>
        public List<clsSearchLogic> GetSearchedInvoices(int invoiceID, DateTime invoiceDate, double invoiceCharge)
        {

            List<clsSearchLogic> lstInvoices = new List<clsSearchLogic>();

            //grab the data from our database, whatever was selected to be searched for by our user
            //lstInvoices.Add(new clsSearchLogic { InvoiceID.invoiceID, InvoiceDate.invoiceDate, InvoiceCharge.invoiceCharge}); 

            return lstInvoices;
        }


        #endregion

        //WE MAY NOT NEED THIS
        #region Properties

        ///<summary>
        /// InvoiceID Property, to get the invoiceID property and set the invoiceID property
        /// </summary>
        public int InvoiceID
        {
            get
            {
                //return our invoiceID from whatever our user selected from our Search Window
                return invoiceID;

            } //end get
            set
            {
                //make sure what we received was of type "int"
                if(value.GetType() == typeof(int))
                {
                    //set invoiceID to the retrieved value
                    invoiceID = value; 
                }
                else
                {
                    //throw a ArgumentException if the invoiceID that was retrieved was not an "int"
                    throw new ArgumentException(String.Format("InvoiceID", value.ToString(), "InvoiceID must be an integer."));
                }
            } //end set
        }

        ///<summary>
        /// InvoiceDate Property, to get the invoiceDate property and set the invoiceDate property
        /// </summary>
        public DateTime InvoiceDate
        {
            get
            {
                //return our invoiceDate 
                return invoiceDate;

            } //end get
            set
            {
                //make sure what we received was of type "DateTime"
                if (value.GetType() == typeof(DateTime))
                {
                    //set invoiceDate to the retrieved value
                    invoiceDate = value;
                }
                else
                {
                    //throw a ArgumentException if the invoiceDate that was retrieved was not an "DateTime"
                    throw new ArgumentException(String.Format("InvoiceDate", value.ToString(), "InvoiceDate must be a DateTime."));
                }
            } //end set
        }


        ///<summary>
        /// InvoiceDate Property, to get the invoiceDate property and set the invoiceDate property
        /// </summary>
        public double InvoiceCharge
        {
            get
            {
                //return our invoiceCharge 
                return invoiceCharge;

            } //end get
            set
            {
                //make sure what we received was of type "double"
                if (value.GetType() == typeof(double))
                {
                    //set invoiceCharge to the retrieved value
                    invoiceCharge = value;
                }
                else
                {
                    //throw a ArgumentException if the invoiceCharge that was retrieved was not an "double"
                    throw new ArgumentException(String.Format("InvoiceCharge", value.ToString(), "InvoiceCharge must be a double."));
                }
            } //end set
        }


        #endregion




    }
}
