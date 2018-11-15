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
        /// a public string for the format of the string, tried to write an overload ToString() but it didn't work so well 
        /// </summary>
        public string format;


        /// <summary>
        /// default constructor
        /// </summary>
        public Invoice()
        {
            invoiceDate = "";
            invoiceNumber = 0;
            totalCost = 0;
            format = ""; 
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

        public Invoice(string date)
        {
            format = "invoiceDate"; //set how we want to format the object in the combo-box
            invoiceDate = date;
            
        }

        public Invoice(int number)
        {
            format = "invoiceID"; //set how we want to format the object in the combo-box
            invoiceNumber = number;

        }
        public Invoice(double cost)
        {
            format = "totalCost";   //set how we want to format the object in the combo-box
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

            if(format == "invoiceDate")
            {
                return invoiceDate; 
            }
            if (format == "totalCost")
            {
                return totalCost.ToString();
            }
            if (format == "invoiceID")
            {
                return invoiceNumber.ToString();
            }
            else
            {
                return invoiceNumber + "\t" + invoiceDate + "\t" + totalCost;
            }
        }

        ///<summary>
        ///original attempt to overrride the ToString method...doesn't quite work
        /// </summary>
      /* public string ToString(string format, Object str)
        {
            switch (format)
            {
                case "invoiceID": return str.ToString();
                case "invoiceDate": return str.ToString();
                case "totalCost": return str.ToString(); 
            }

            return this.ToString(); 
        }*/


    }
}
