using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_3280_Group_Assignment
{
    class Invoice
    {
        /// <summary>
        /// Invoice number
        /// </summary>
        protected int invoiceNumber;

        /// <summary>
        /// invoiceDate
        /// </summary>
        protected string invoiceDate;

        /// <summary>
        /// total cost
        /// </summary>

        protected double totalCost;


        /// <summary>
        /// default constructor
        /// </summary>
        public Invoice()
        {
            invoiceDate = "";
            invoiceNumber = 0;
            totalCost = 0;
        }

        /// <summary>
        /// Constructor to assign values
        /// </summary>
        /// <param name="number">invoice number</param>
        /// <param name="date">Invoice date</param>
        /// <param name="cost">total cost</param>

        public Invoice(int number, string date, double cost)
        {
            invoiceNumber = number;
            invoiceDate = date;
            totalCost = cost;
        }

        /// <summary>
        /// Invoice Number
        /// </summary>
        public int InvoiceNumber
        {
            get
            {
                return invoiceNumber;
            }
            set
            {
                invoiceNumber = value;
            }
        }

        /// <summary>
        /// Invoice Date
        /// </summary>
        public string InvoiceDate
        {
            get
            {
                return invoiceDate;
            }
            set
            {
                invoiceDate = value;
            }
        }

        /// <summary>
        /// Total Cost
        /// </summary>
        public double TotalCost
        {
            get
            {
                return totalCost;
            }
            set
            {
                totalCost = value;
            }
        }

        /// <summary>
        /// over ride to string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return invoiceNumber + "      " + invoiceDate + "      " + totalCost;
        }


    }
}
