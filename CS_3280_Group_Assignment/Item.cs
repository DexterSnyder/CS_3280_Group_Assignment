using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_3280_Group_Assignment
{
    class Item
    {
        /// <summary>
        /// Item Code
        /// </summary>
        protected string itemCode;

        /// <summary>
        /// Item Description
        /// </summary>
        protected string itemDesc;

        /// <summary>
        /// Cost
        /// </summary>
        protected double cost;


        /// <summary>
        /// constructor
        /// </summary>
        public Item()
        {
            itemCode = "";
            itemDesc = "";
            cost = 0;
        }

        public Item(string code, string desc, double cost1)
        {
            itemCode = code;
            itemDesc = desc;
            cost = cost1;
        }

        /// <summary>
        /// Invoice Number
        /// </summary>
        public string ItemCode
        {
            get
            {
                return itemCode;
            }
            set
            {
                itemCode = value;
            }
        }

        /// <summary>
        /// Invoice Date
        /// </summary>
        public string ItemDesc
        {
            get
            {
                return ItemDesc;
            }
            set
            {
                ItemDesc = value;
            }
        }

        /// <summary>
        /// Total Cost
        /// </summary>
        public double Cost
        {
            get
            {
                return cost;
            }
            set
            {
                cost = value;
            }
        }

        /// <summary>
        /// over ride to string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return itemCode + "\t" + "$" + cost + "\t" + itemDesc;
        }



    }
}
